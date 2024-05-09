using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseCount : MonoBehaviour
{
    public static CheeseCount instance;
    public List<CheesePickup> items = new List<CheesePickup>();
    public int cheeseNumber = 0;
    // public GameObject uiLevelEnd; (assign the Level End screen here)

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
                cheeseNumber += 1;
                break;
            }
        }
        if (!itemExists)
        {
            items.Add(itemToAdd);
            cheeseNumber += 1;
        }
        Debug.Log(itemToAdd.count + " " + itemToAdd.moniker + " collected!");
    }

    public void WinCon()
    {
        if (cheeseNumber == 4)
        {
            Debug.Log("You Win!");
            // Connect the uiLevelEnd here!
        }
    }

}
