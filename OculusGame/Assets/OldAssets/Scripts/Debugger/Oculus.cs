using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class Oculus : MonoBehaviour {

	// Use this for initialization
	void Start () {

        VRSettings.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.A))
        {
            VRSettings.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            VRSettings.enabled = false;
        }
	}
}
