using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Waffle : MonoBehaviour
{
    public AudioClip blipp;
    public AudioClip goal;

    public float speed = 200;

    private Vector2 velocity;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        // Determine what was hit.
        switch (collision.gameObject.tag)
        {
            case "Goal":
                GameEvents.singleton.mainAudio.PlayOneShot(goal);
                RoundEvents.singleton.ScoreGoal(collision.gameObject);
                Destroy(this.gameObject);
                break;
            default:
                GameEvents.singleton.mainAudio.PlayOneShot(blipp);
                break;
        }

    }
}
