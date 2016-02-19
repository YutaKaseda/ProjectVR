using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class VRDev : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
           VRSettings.enabled = false;
    }
}
