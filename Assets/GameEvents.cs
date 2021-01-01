using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvents : MonoBehaviour
{
    protected bool IsGamePaused = false;
    public static GameEvents singleton;
    public event Action OnGameResume;
    public event Action OnGamePause;
    public event Action OnRoundStart;

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
        if (OnGamePause != null)
        {
            IsGamePaused = true;
            Time.timeScale = 0;
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
        if (OnGameResume != null)
        {
            IsGamePaused = false;
            Time.timeScale = 1;
            OnGameResume();
        }
    }
    
    public void RoundStart()
    {
        if (OnRoundStart != null)
        {
            OnRoundStart();
        }
    }

    public void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            OnRoundStart();
        }
    }


}
