using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    private Inventory inventory;
    public int numberItem;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!inventory.isFull[numberItem])
            {
              inventory.isFull[numberItem] = true;
              inventory.slots[numberItem].GetComponent<Image>().enabled = true;
              Destroy(gameObject);
            }
        }
    }
}
