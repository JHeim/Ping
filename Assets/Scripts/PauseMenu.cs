using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject PauseMenuInstance;
    public GameObject PauseMenuPrefab;

    // Start is called before the first frame update
    void Start()
    {
        if (GameEvents.singleton != null)
        {
            GameEvents.singleton.OnGamePause += EnablePauseMenu;
            GameEvents.singleton.OnGameResume += DisablePauseMenu;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnablePauseMenu()
    {
        PauseMenuInstance.SetActive(true);
    }

    void DisablePauseMenu()
    {
        PauseMenuInstance.SetActive(false);
    }
}
