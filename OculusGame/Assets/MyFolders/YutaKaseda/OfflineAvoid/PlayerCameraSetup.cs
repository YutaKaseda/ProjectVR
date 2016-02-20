using UnityEngine;
using System.Collections;

public class PlayerCameraSetup : MonoBehaviour {

    [SerializeField]
    AudioListener myAudioListener;
    [SerializeField]
    Camera myCamera;

    public void SetupLocalPlayer()
    {

        GameObject.FindWithTag("SceneCamera").SetActive(false);

        myAudioListener.enabled = true;
        myCamera.enabled = true;

        if (gameObject.tag == "Player2D")
            GetComponent<Player2D>().enabled = true;
    }

}
