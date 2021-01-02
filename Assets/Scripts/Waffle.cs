using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody2D))]
public class Waffle : MonoBehaviour
{
    public float speed = 200;

    private Vector2 velocity;
    private AudioSource audioSource;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        // Determine what was hit.
        switch (collision.gameObject.tag)
        {
            case "Goal":
                RoundEvents.singleton.ScoreGoal(collision.gameObject);
                Destroy(this.gameObject);
                break;
            default:
                audioSource.Play();
                break;
        }

    }
}
