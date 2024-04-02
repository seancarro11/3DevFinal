using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    
    private int score;
    public TextMeshProUGUI scoreText;
    public bool isGameActive;
    public GameObject startScreen;
    public GameObject levelEndScreen;
    public GameObject optionsScreen;
    public GameObject controlsScreen;
    public GameObject gameOverScreen;
    public GameObject pauseScreen;
    public GameObject gameHUD;

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        PauseGame();
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
        gameOverScreen.gameObject.SetActive(false);
        pauseScreen.gameObject.SetActive(false);
        gameHUD.SetActive(false);
        //reset the game somehow, maybe just simply reload scene from start
    }

    public void OpenOptions()
    {
        startScreen.gameObject.SetActive(false);
        levelEndScreen.gameObject.SetActive(false);
        optionsScreen.gameObject.SetActive(true);
        controlsScreen.gameObject.SetActive(false);
        gameOverScreen.gameObject.SetActive(false);
        pauseScreen.gameObject.SetActive(false);
        gameHUD.SetActive(false);
    }

    public void OpenControls()
    {
        startScreen.gameObject.SetActive(false);
        levelEndScreen.gameObject.SetActive(false);
        optionsScreen.gameObject.SetActive(false);
        controlsScreen.gameObject.SetActive(true);
        gameOverScreen.gameObject.SetActive(false);
        pauseScreen.gameObject.SetActive(false);
        gameHUD.SetActive(false);
    }

    public void PauseGame()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            pauseScreen.gameObject.SetActive(true);
            startScreen.gameObject.SetActive(false);
            levelEndScreen.gameObject.SetActive(false);
            optionsScreen.gameObject.SetActive(false);
            controlsScreen.gameObject.SetActive(false);
            gameOverScreen.gameObject.SetActive(false);
            //disable player and enemy movement, and also stop timer if there is one
        }
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
