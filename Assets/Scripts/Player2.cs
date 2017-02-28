using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour {

    private float gravity = 20.0f;
    private float jump = 4.0f;
    private float speed = 0.1f;

    private Rigidbody2D body;
    public bool isGrounded;
    // Use this for initialization
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            body.velocity = new Vector2(0, jump);
        }
        if (Input.GetKey(KeyCode.A)) 
        {
            transform.Translate(-speed, 0, 0);
        } else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed, 0, 0);
        }
    }

    void OnCollisionStay2D(Collision2D box)
    {
        isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D box)
    {
        isGrounded = false;
    }
}
