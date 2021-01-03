using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : NetworkBehaviour
{
    public float speed = 25f;

    private Rigidbody2D rb;

    float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (GameEvents.singleton.isSingleplayer || this.isLocalPlayer)
        {
            movementY = Input.GetAxisRaw("Vertical") * speed;
        }
        

        if (Input.GetButtonDown("Pause") && SceneManager.GetActiveScene() != SceneManager.GetSceneByName("MainMenu"))
        {
            GameEvents.singleton.TogglePause();
        }


    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(0, movementY));

        
    }

}
