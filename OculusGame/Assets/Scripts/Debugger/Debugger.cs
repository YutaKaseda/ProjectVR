using UnityEngine;
using System.Collections;
using UnityEngine.VR;
using UnityEngine.Networking;

public class Debugger : MonoBehaviour {

    [SerializeField]
    GameObject networkManager;

	// Use this for initialization
	void Start () {
        networkManager = GameObject.Find("GameManager");
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.A))
        {
            networkManager.GetComponentInChildren<NetworkManager>().onlineScene = "Assets/Scenes/3DGameMain";
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            networkManager.GetComponentInChildren<NetworkManager>().onlineScene = "Assets/Scenes/2DGameMain";
        }

	}
}
