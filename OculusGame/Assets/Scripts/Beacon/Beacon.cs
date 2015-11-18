using UnityEngine;
using System.Collections;

public class Beacon : MonoBehaviour {

    bool putFlg;

    void Awake()
    {
        ResourcesManager.Instance.ResourcesLoadScene("Play");
        putFlg = false;
    }

    void Update()
    {
        BeaconPut();
    }

    void BeaconPut()
    {
        if (putFlg == false)
        {
            if (Input.GetButton("BatuP2"))
            {
                Instantiate(ResourcesManager.Instance.GetResourceScene("BabelBeacon"), transform.position, transform.rotation);
                putFlg = true;
            }
        }
        else{

        }
    }

}
