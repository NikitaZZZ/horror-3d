using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DripTrigger : MonoBehaviour
{
    [SerializeField] public AudioSource dripAudio;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {  dripAudio.Play(); }
    }

    void Start()
    {
        Debug.Log(dripAudio);
    }

    void Update()
    {
        
    }
}
