using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseCount : MonoBehaviour
{
    public static CheeseCount instance;
    public List<CheesePickup> items = new List<CheesePickup>();

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    public void AddItem(CheesePickup itemToAdd)
    {
        bool itemExists = false;

        foreach (CheesePickup item in items)
        {
            if(item.moniker == itemToAdd.moniker)
            {
                item.count += itemToAdd.count;
                itemExists = true;
                break;
            }
        }
        if (!itemExists)
        {
            items.Add(itemToAdd);
        }
        Debug.Log(itemToAdd.count + " " + itemToAdd.moniker + " collected!");
    }
}
