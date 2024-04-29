using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    
    public GameObject startScreen;
    public GameObject levelEndScreen;
    public GameObject optionsScreen;
    public GameObject controlsScreen;
    public GameObject gameOverScreen;
    public GameObject pauseScreen;
    public GameObject gameHUD;

    public bool isGameActive = false;
    public Rigidbody playerRb;

    public CharacterControllerZach controllerVariable;

    void Start()
    {
        
    }

    void Update()
    {
        PauseGame();
        LevelEnd();
        FreezePlayer();
    }

    public void StartGame()
    {
        
        SceneManager.LoadScene(1);
        startScreen.gameObject.SetActive(false);
        levelEndScreen.gameObject.SetActive(false);
        optionsScreen.gameObject.SetActive(false);
        controlsScreen.gameObject.SetActive(false);
        gameOverScreen.gameObject.SetActive(false);
        pauseScreen.gameObject.SetActive(false);
        gameHUD.gameObject.SetActive(true);
        isGameActive = true;
    }
    
    public void BackToMainMenu()
    {
        isGameActive = false;
        SceneManager.LoadScene(0);
        startScreen.gameObject.SetActive(true);
        levelEndScreen.gameObject.SetActive(false);
        optionsScreen.gameObject.SetActive(false);
        controlsScreen.gameObject.SetActive(false);
        gameOverScreen.gameObject.SetActive(false);
        pauseScreen.gameObject.SetActive(false);
        gameHUD.gameObject.SetActive(false);
    }

    public void OpenOptions()
    {
        startScreen.gameObject.SetActive(false);
        levelEndScreen.gameObject.SetActive(false);
        optionsScreen.gameObject.SetActive(true);
        controlsScreen.gameObject.SetActive(false);
        gameOverScreen.gameObject.SetActive(false);
        pauseScreen.gameObject.SetActive(false);
        gameHUD.gameObject.SetActive(false);
    }

    public void OpenControls()
    {
        startScreen.gameObject.SetActive(false);
        levelEndScreen.gameObject.SetActive(false);
        optionsScreen.gameObject.SetActive(false);
        controlsScreen.gameObject.SetActive(true);
        gameOverScreen.gameObject.SetActive(false);
        pauseScreen.gameObject.SetActive(false);
        gameHUD.gameObject.SetActive(false);
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
            gameHUD.gameObject.SetActive(false);
            //disable player and enemy movement, and also stop timer if there is one
            isGameActive = false;
        }
    }

    public void backToPause()
    {
        pauseScreen.gameObject.SetActive(true);
        startScreen.gameObject.SetActive(false);
        levelEndScreen.gameObject.SetActive(false);
        optionsScreen.gameObject.SetActive(false);
        controlsScreen.gameObject.SetActive(false);
        gameOverScreen.gameObject.SetActive(false);
        gameHUD.gameObject.SetActive(false);
    }

    public void Unpause()
    {
        pauseScreen.gameObject.SetActive(false);
        startScreen.gameObject.SetActive(false);
        levelEndScreen.gameObject.SetActive(false);
        optionsScreen.gameObject.SetActive(false);
        controlsScreen.gameObject.SetActive(false);
        gameOverScreen.gameObject.SetActive(false);
        gameHUD.gameObject.SetActive(true);

        isGameActive = true;
    }

    public void LevelEnd()
    {
        if (controllerVariable.cheeseScore >= 12)
        {
            pauseScreen.gameObject.SetActive(false);
            startScreen.gameObject.SetActive(false);
            levelEndScreen.gameObject.SetActive(true);
            optionsScreen.gameObject.SetActive(false);
            controlsScreen.gameObject.SetActive(false);
            gameOverScreen.gameObject.SetActive(false);
            gameHUD.gameObject.SetActive(false);

            isGameActive = false;
        }
        
    }

    public void GameOver()
    {
        //if (shopkeep makes contact with mouse)
        //{
        //    die
        //}
        
        pauseScreen.gameObject.SetActive(false);
        startScreen.gameObject.SetActive(false);
        levelEndScreen.gameObject.SetActive(false);
        optionsScreen.gameObject.SetActive(false);
        controlsScreen.gameObject.SetActive(false);
        gameOverScreen.gameObject.SetActive(true);
        gameHUD.gameObject.SetActive(false);

        isGameActive = false;
    }

    public void FreezePlayer()
    {
        if (isGameActive == false)
        {
            playerRb.constraints = RigidbodyConstraints.FreezePosition;
            playerRb.constraints = RigidbodyConstraints.FreezeRotation;
        }
        if (isGameActive == true)
        {
            playerRb.constraints = RigidbodyConstraints.None;
            playerRb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        }
    }
}
