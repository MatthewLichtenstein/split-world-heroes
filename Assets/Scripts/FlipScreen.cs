using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipScreen : MonoBehaviour {
    public bool topScreen;

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
	}
}
