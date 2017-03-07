using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponQuality : MonoBehaviour
{

    private Rigidbody2D rigid;

    public bool isPotion;
    public Player2 player2;
    public Player1 player1;
    private Transform trans;

    private bool thrust;
    private int thrtimer;
    // Use this for initialization
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        thrtimer = 0;
        thrust = false;
        trans = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPotion && !thrust && Input.GetKeyDown(KeyCode.RightShift))
        {
            thrust = true;
            thrtimer = 60;
        }
        if (thrust)
        {
            if (thrtimer > 30)
            {
                trans.Translate(2 * Time.deltaTime, 0, 0);
                thrtimer--;
            }
            else if (thrtimer > 0)
            {
                trans.Translate(-2 * Time.deltaTime, 0, 0);
                thrtimer--;
            }
            else
            {
                thrust = false;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isPotion)
        {
            Destroy(gameObject);
            player2.thrown = false;
            if (other.transform.root.GetComponent<RedEnemy>())
            {
                Destroy(other.transform.gameObject);
            }
        }
        else if (other.transform.root.GetComponent<GreenEnemy>())
        {
            Destroy(other.transform.gameObject);
        }

        if (other.transform.root.GetComponent<FlipScreen>())
        {
            Destroy(other.transform.gameObject);
        }
    }

    public Rigidbody2D getBody()
    {
        return rigid;
    }
}
