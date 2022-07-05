using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private Inventory inventory;
    public GameObject slotButton;
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
              Instantiate(slotButton, inventory.slots[numberItem].transform);
              Destroy(gameObject);
            }
        }
    }
}
