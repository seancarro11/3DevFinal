using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    
    private int score;
    public TextMeshProUGUI scoreText;
    public bool isGameActive;
    public GameObject startScreen;
    public GameObject levelEndScreen;
    public GameObject optionsScreen;
    public GameObject controlsScreen;

    void Start()
    {
        score = 0;
        
    }

    void Update()
    {
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Cheese: " + score;
    }

    public void BackToMainMenu()
    {
        startScreen.gameObject.SetActive(true);
        levelEndScreen.gameObject.SetActive(false);
        optionsScreen.gameObject.SetActive(false);
        controlsScreen.gameObject.SetActive(false);
    }

    public void OpenOptions()
    {
        startScreen.gameObject.SetActive(false);
        levelEndScreen.gameObject.SetActive(false);
        optionsScreen.gameObject.SetActive(true);
        controlsScreen.gameObject.SetActive(false);
    }

    public void OpenControls()
    {
        startScreen.gameObject.SetActive(false);
        levelEndScreen.gameObject.SetActive(false);
        optionsScreen.gameObject.SetActive(false);
        controlsScreen.gameObject.SetActive(true);
    }

    // Going to need to put the below commented text in the player movement script:
    //
    //private GameManager gameManager;
    //
    //void Start()
    //{
    //gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    //}
    //
    //private void OnTriggerEnter()
    //{
    //    gameManager.UpdateScore(1);
    //}
}
