using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AIController : MonoBehaviour
{
    public float speed = 1;

    public GameObject ball;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    private void FixedUpdate()
    {
        if (ball != null  && GameEvents.singleton.GetGamePaused() == false)
        {
            var ballPosition = ball.transform.position;

            if (ballPosition.y > transform.position.y)
            {
                rb.AddForce(new Vector2(0, speed));
            }
            else if (ballPosition.y < transform.position.y)
            {
                rb.AddForce(new Vector2(0, -speed));
            }
        }
    }
}
