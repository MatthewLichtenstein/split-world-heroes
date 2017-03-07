using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Player1 : MonoBehaviour {

    private float gravity = 20.0f;
    private float jump = 4.0f;
    private float speed = 0.1f;
    
    private Rigidbody2D body;
    public bool isGrounded;
    public GameObject sword;
    private GameObject instance;
    private Transform trans;
    public bool thrown;
	// Use this for initialization
	void Start () {
        body = gameObject.GetComponent<Rigidbody2D>();
        trans = gameObject.GetComponent<Transform>();
        thrown = false;
	}
	
	// Update is called once per frame
	void Update () {
       if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            body.velocity = new Vector2(0, jump);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightShift) && !thrown)
        {
            instance = (GameObject)Instantiate(sword, transform.localPosition + new Vector3(1.05f, 0.06f, 0), Quaternion.AngleAxis(-90,Vector3.forward));
            instance.GetComponent<Rigidbody2D>().AddForce(new Vector2(160, 0));
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
