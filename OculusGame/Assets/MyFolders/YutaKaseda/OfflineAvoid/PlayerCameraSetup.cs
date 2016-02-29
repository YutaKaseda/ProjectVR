using UnityEngine;
using System.Collections;

public class PlayerCameraSetup : MonoBehaviour
{

    [SerializeField]
    Camera myCamera;

    [SerializeField]
    AudioListener audioListener;

    public void SetUpPlayer()
    {

        if (gameObject.tag == "Player2D")
        {
            GameObject.FindWithTag("SceneCamera2D").SetActive(false);
            myCamera.enabled = true;
            //GetComponent<Player2D>().enabled = true;
        }

        if (gameObject.tag == "Player3D")
        {
            GameObject.FindWithTag("SceneCameraOculus").SetActive(false);
            myCamera.enabled = true;
            audioListener.enabled = true;
        }

        

    }
}
