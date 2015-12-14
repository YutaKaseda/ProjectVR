using UnityEngine;
using System.Collections;
using UnityEngine.VR;
using OfflineStatus;
using GameMainData;

public class Debugger : MonoBehaviour {

	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.A))
        {
            GameData.offlineState = E_OFFLINE_STATE.NETWORK_SETUP;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {

        }

	}
}
