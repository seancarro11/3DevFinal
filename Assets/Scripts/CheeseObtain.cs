using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseObtain : MonoBehaviour
{
    public CheesePickup item = new CheesePickup("Item Name", 1);
    public int cheeseNumber = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CheeseCount.instance.AddItem(item);
            Destroy(gameObject);
            cheeseNumber += 1;

            if (cheeseNumber >= 10)
            {
                Debug.Log("You Win!");
            }

        }
    }
}
