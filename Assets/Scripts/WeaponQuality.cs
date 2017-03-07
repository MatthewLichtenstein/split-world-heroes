using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponQuality : MonoBehaviour {

    private Rigidbody2D rigid;

    public bool isPotion;
    public Player2 player2;
    public Player1 player1;
    private Transform trans;

    
	// Use this for initialization
	void Start () {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        trans = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        
        Destroy(gameObject);
        if (isPotion)
        {
            player2.thrown = false;
        }
        else
        {
            player1.thrown = false;
        }
    }

    public Rigidbody2D getBody()
    {
        return rigid;
    }
}
