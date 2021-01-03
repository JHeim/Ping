using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundEvents : MonoBehaviour
{
    public static RoundEvents singleton;

    public Transform p1Spawn;
    public Transform p2Spawn;

    [HideInInspector]
    public GameObject player1;
    [HideInInspector]
    public GameObject player2;

    public GameObject p1Goal;
    public GameObject p2Goal;

    public GameObject waffle;

    public int p1Score = 0;
    public int p2Score = 0;

    public event Action OnRoundStart;

    public event Action<GameObject> OnScoreGoal;

    private AIController aiController;

    private void Awake()
    {
        singleton = this;
    }


    private void Start()
    {
        // Instantiate the players.
        if (GameEvents.singleton.isSingleplayer)
        {
            player1 = Instantiate(GameEvents.singleton.player1, p1Spawn.position, p1Spawn.rotation);
            player2 = Instantiate(GameEvents.singleton.player2, p2Spawn.position, p2Spawn.rotation);
            aiController = player2.GetComponent<AIController>();
        }
        
        // Begin round-start timer.
        RoundCountdown();
        RoundStart();


    }

    public void RoundStart()
    {
        // Spawn a waffle x: 0, y: 0 - 3
        var waffleInstance = Instantiate(waffle, new Vector2(0, 0), Quaternion.identity);
        if (GameEvents.singleton.isSingleplayer)
        {
            // Tell the enemy AI what the target is.
            aiController.target = waffleInstance;
        }

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
        if (goal == p1Goal)
        {
            p1Score += 1;
        }
        else
        {
            p2Score += 1;
        }

        if (OnScoreGoal != null)
        {
            
            OnScoreGoal(goal);
        }

        EndRound();
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
