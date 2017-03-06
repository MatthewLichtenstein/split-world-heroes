using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipScreen : MonoBehaviour {
    public bool topScreen;
    public float speed = 0.1f;
    public Transform P1Transform;
    public Transform P2Transform;

    // Use this for initialization
    void Start () {
        topScreen = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            if (topScreen)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 5f, 0);
                topScreen = false;
            } else
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 5f, 0);
                topScreen = true;
            }
        }

        if(topScreen)
        {
            Vector3 direction = P1Transform.position - gameObject.transform.position;
            var distance = direction.magnitude;
            gameObject.transform.Translate(direction/distance * Time.deltaTime);
        } else
        {
            Vector3 direction = P2Transform.position - gameObject.transform.position;
            var distance = direction.magnitude;
            gameObject.transform.Translate(direction / distance * Time.deltaTime);
        }
	}
}
