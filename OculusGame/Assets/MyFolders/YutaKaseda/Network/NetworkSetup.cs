//<Summary>
//Yutakaseda
//16/2/17
//</Summary>

using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkSetup : NetworkBehaviour {

	[SerializeField]
	AudioListener myAudioListener;
	[SerializeField]
	Camera myCamera;

	//LocalPlayerInit
	public override void OnStartLocalPlayer(){

        if (tag == "Player2D"){
            OnlineLevel.Instance.player2DConnected = true;
            OnlineLevel.Instance.localPlayer = gameObject;
        }
        if (tag == "Player3D"){
            OnlineLevel.Instance.localPlayer = gameObject;
        }
	}

    public void SetupLocalPlayer(){

        GameObject.FindWithTag("SceneCamera").SetActive(false);

        myAudioListener.enabled = true;
        myCamera.enabled = true;

        if (gameObject.tag == "Player2D")
            GetComponent<Player2D>().enabled = true;
    }

}
