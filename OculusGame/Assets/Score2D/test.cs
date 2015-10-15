using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

    GameObject scoreManager;

	// Use this for initialization
	void Awake () {
        scoreManager = GameObject.Find("DataManager");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            scoreManager.GetComponent<ScoreManager>().plusScore(20000);
        }
	}
}
