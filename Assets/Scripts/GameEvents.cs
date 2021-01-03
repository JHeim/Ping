using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameEvents : MonoBehaviour
{
    public AudioSource mainAudio;

    public AudioClip clickClip;

    public GameObject playerPrefab;
    public GameObject BotPlayerPrefab;

    public GameObject player1;
    public GameObject player2;

    public bool isSingleplayer = true;
    protected bool IsGamePaused = false;
    public static GameEvents singleton;
    public event Action OnGameResume;
    public event Action OnGamePause;
    public event Action OnLoadMainMenuScene;
    public event Action OnLoadGameScene;
    
    public void PlayClickSound()
    {
        singleton.mainAudio.PlayOneShot(clickClip);
    }


    private void Awake()
    {
        singleton = this;
    }

    public bool GetGamePaused()
    {
        return IsGamePaused;
    }

    public void GamePause()
    {
        IsGamePaused = true;
        Time.timeScale = 0;
        if (OnGamePause != null)
        {
            OnGamePause();
        }
    }

    public void TogglePause()
    {
        if (IsGamePaused == true)
        {
            GameResume();
        }
        else
        {
            GamePause();
        }
    }

    public void GameResume()
    {
        singleton.IsGamePaused = false;
        Time.timeScale = 1;
        if (singleton.OnGameResume != null)
        {
            singleton.OnGameResume();
        }
    }


    
    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");

        IsGamePaused = false;
        Time.timeScale = 1;

        if (isSingleplayer)
        {
            player1 = (playerPrefab);
            player2 = (BotPlayerPrefab);

            
        }

        if (OnLoadGameScene != null)
        {
            OnLoadGameScene();
        }
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("MainMenu");

        if (OnLoadMainMenuScene != null)
        {
            OnLoadMainMenuScene();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
