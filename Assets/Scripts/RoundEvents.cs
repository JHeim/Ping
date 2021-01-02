using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundEvents : MonoBehaviour
{
    public static RoundEvents singleton;

    public GameObject opponent;

    public GameObject playerGoal;
    public GameObject opponentGoal;

    public GameObject waffle;

    public int playerScore = 0;
    public int opponentScore = 0;

    public event Action OnRoundStart;

    public event Action<GameObject> OnScoreGoal;

    private void Awake()
    {
        singleton = this;
    }


    private void Start()
    {

        // Begin round-start timer.
        RoundCountdown();
        RoundStart();
    }

    public void RoundStart()
    {
        // Spawn a waffle x: 0, y: 0 - 3
        var waffleInstance = Instantiate(waffle, new Vector2(0, 0), Quaternion.identity);

        // Tell the enemy AI what the ball is.
        var aiController = opponent.GetComponent<AIController>();
        aiController.ball = waffleInstance;

        // Apply force to waffle.
        float y = UnityEngine.Random.Range(1, 4) * 100;
        Vector2 force = new Vector2(-200, y);
        var rb = waffleInstance.GetComponent<Rigidbody2D>();
        rb.AddForce(force);

        if (OnRoundStart != null)
        {
            OnRoundStart();
        }
    }

    public void ScoreGoal(GameObject goal)
    {
        if (OnScoreGoal != null)
        {
            if (goal == playerGoal)
            {
                playerScore += 1;
            }
            else
            {
                opponentScore += 1;
            }

            EndRound();
            OnScoreGoal(goal);
        }
    }

    public void EndRound()
    {
        RoundCountdown();
        RoundStart();
    }

    private IEnumerator RoundCountdown()
    {
        float duration = 3f;
        float totalTime = 0;

        while (totalTime <= duration)
        {
            totalTime += Time.deltaTime;
            yield return null;
        }

    }
}
