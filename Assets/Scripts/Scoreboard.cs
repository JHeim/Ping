using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    public Text playerScoreUI;
    public Text opponentScoreUI;

    // Start is called before the first frame update
    void Start()
    {
        RoundEvents.singleton.OnScoreGoal += UpdateScoreboard;
    }

    void UpdateScoreboard(GameObject goal)
    {
        playerScoreUI.text = RoundEvents.singleton.p1Score.ToString();
        opponentScoreUI.text = RoundEvents.singleton.p2Score.ToString();
    }
}
