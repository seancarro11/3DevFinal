using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinConditionPlus : MonoBehaviour
{
    int Score;

    void Update()
    {
        if (Score >= 6)
        {
            SceneManager.LoadScene("LevelEndScene", LoadSceneMode.Single);
        }
    }

    private void OnTriggerEnter(Collider cheese)
    {
        if (cheese.CompareTag("Cheese"))
        {
            Debug.Log("Collected a piece of cheese!");

            Destroy(cheese.gameObject);
           
            Score++;
        }
    }
}