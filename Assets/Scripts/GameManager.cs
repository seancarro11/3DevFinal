using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    
    
    public GameObject startScreen;
    public GameObject levelEndScreen;
    public GameObject optionsScreen;
    public GameObject controlsScreen;
    public GameObject gameOverScreen;
    public GameObject pauseScreen;
    public GameObject gameHUD;

    public bool isGameActive;

    void Start()
    {
        isGameActive = false;
    }

    void Update()
    {
        PauseGame();
    }

    public void StartGame()
    {
        startScreen.gameObject.SetActive(false);
        levelEndScreen.gameObject.SetActive(false);
        optionsScreen.gameObject.SetActive(false);
        controlsScreen.gameObject.SetActive(false);
        gameOverScreen.gameObject.SetActive(false);
        pauseScreen.gameObject.SetActive(false);
        gameHUD.SetActive(true);
        //reset the game somehow, maybe just simply reload scene from start
        isGameActive = true;
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
            gameHUD.SetActive(false);
            //disable player and enemy movement, and also stop timer if there is one
            isGameActive = false;
        }
    }

    public void Unpause()
    {
        pauseScreen.gameObject.SetActive(false);
        startScreen.gameObject.SetActive(false);
        levelEndScreen.gameObject.SetActive(false);
        optionsScreen.gameObject.SetActive(false);
        controlsScreen.gameObject.SetActive(false);
        gameOverScreen.gameObject.SetActive(false);
        gameHUD.SetActive(true);

        isGameActive = true;
    }

    public void LevelEnd()
    {
        pauseScreen.gameObject.SetActive(false);
        startScreen.gameObject.SetActive(false);
        levelEndScreen.gameObject.SetActive(true);
        optionsScreen.gameObject.SetActive(false);
        controlsScreen.gameObject.SetActive(false);
        gameOverScreen.gameObject.SetActive(false);
        gameHUD.SetActive(false);

        isGameActive = false;
    }

    public void GameOver()
    {
        pauseScreen.gameObject.SetActive(false);
        startScreen.gameObject.SetActive(false);
        levelEndScreen.gameObject.SetActive(false);
        optionsScreen.gameObject.SetActive(false);
        controlsScreen.gameObject.SetActive(false);
        gameOverScreen.gameObject.SetActive(true);
        gameHUD.SetActive(false);

        isGameActive = false;
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
