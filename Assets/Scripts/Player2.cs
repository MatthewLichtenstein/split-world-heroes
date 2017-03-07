using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour {

    private float gravity = 20.0f;
    private float jump = 4.0f;
    private float speed = 0.1f;

    private Rigidbody2D body;
    public bool isGrounded;
    public GameObject potion;
    private GameObject instance;
    private Transform trans;
    public bool thrown;
    // Use this for initialization
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        trans = gameObject.GetComponent<Transform>();
        thrown = false;
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
        if (Input.GetKeyDown(KeyCode.E) && !thrown)
        {
            instance = (GameObject)Instantiate(potion, transform.localPosition + new Vector3(0.91f, 0.59f, 0), transform.rotation);
            instance.GetComponent<Rigidbody2D>().AddForce(new Vector2(160, 80));
            instance.GetComponent<Rigidbody2D>().gravityScale = 1;
            thrown = true;
        }
    }

    void OnCollisionStay2D(Collision2D box)
    {
        if (box.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D box)
    {
        isGrounded = false;
    }
}
