using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickSound : Button
{

    protected override void Start()
    {
        playClickSound();
    }
    void playClickSound()
    {
        GameEvents.singleton.mainAudio.PlayOneShot(GameEvents.singleton.clickClip);
    }
}
