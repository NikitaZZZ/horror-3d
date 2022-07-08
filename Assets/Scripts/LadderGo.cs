using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class LadderGo : MonoBehaviour
{
  public float Go = 100f;
  public float range = 3f;

  public GameObject LadderUp;
  public bool isRising = false;

  public Camera fpsCam;

    void Update()
    {
      if (Input.GetKeyDown("f"))
      {
        Shoot();
      }
    }

    void Shoot()
    {
      RaycastHit hit;
      if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
      {
        Target target = hit.transform.GetComponent<Target>();
        if (target != null)
        {
          StartCoroutine(UpLadder());
        }
      }
    }

    IEnumerator UpLadder() 
    {
      isRising = true;
      LadderUp.GetComponent<Animator>().Play("LadderUp");
      yield return new WaitForSeconds(0.05f);
      yield return new WaitForSeconds(5f);
      LadderUp.GetComponent<Animator>().Play("New State");
      isRising = false;
    }
}
