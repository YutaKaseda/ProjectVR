using UnityEngine;
using System.Collections;

public class Debugger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.A))
        {
            ResourcesManager.Instance.ResourcesLoadScene("Play");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            ResourcesManager.Instance.ResourcesUnLoadAll();
        }

	}
}
