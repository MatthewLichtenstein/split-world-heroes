using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public Canvas victoryScreen;
    public bool done;

    // Use this for initialization
    void Start () {
        done = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectsWithTag("Enemy") == null || GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            victoryScreen.gameObject.SetActive(true);
            done = true;
        }

        if(done)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Game2");
            }
        }
	}
}
