using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float movementY = Input.GetAxisRaw("Vertical");

        rb.AddForce(new Vector2(0, movementY));

        if (Input.GetButtonDown("Pause"))
        {
            GameEvents.singleton.TogglePause();
        }
        


    }

    private void FixedUpdate()
    {
        
    }

}
