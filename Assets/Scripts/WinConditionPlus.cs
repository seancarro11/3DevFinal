using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinConditionPlus : MonoBehaviour
{
    int Score = 0;

    void Update()
    {
        if (Score >= 6)
        {
            Debug.Log("You Win!");
        }
    }

    private void OnTriggerEnter(Collider cheese)
    {
        if (cheese.CompareTag("Cheese"))
        {
            Debug.Log("Collected a piece of cheese!");
           
            Score = Score + 1;
            

           
        }
     
    }
    
}