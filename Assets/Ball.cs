using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    public float speed = 200;
    
    private AudioSource audioSource;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.singleton.OnRoundStart += OnBallMove;

        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnBallMove()
    {
        float y = Random.Range(1, 4) * 100;

        rb.AddForce(new Vector2(-speed, y));
    }

    // Replace physics (Dynamic) with scripted events. (Kinematic)
    // Angle ball should travel dependent on where it hit the transform.
    // Center should have no modified angle. 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.Play();
    }
}
