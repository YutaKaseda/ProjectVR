using UnityEngine;
using System.Collections;

public class Beacon : MonoBehaviour {

    public bool putFlg { get; private set; }
    public bool moveFlg { get; private set; }
    public float time { get; private set; }
    public float interval { get; private set; }
    public float waitTime { get; private set; }

    void Awake()
    {
        ResourcesManager.Instance.ResourcesLoadScene("Play");
        putFlg = false;
        time = 0;
        waitTime = 3;
        interval = 10;
        moveFlg = false;
    }

    public void BeaconPut()
    {
        if (putFlg == false)
        {
            if (Input.GetButton("BatuP2"))  //ばつが押されている間
            {
                time += Time.deltaTime;
                moveFlg = true;

                if (time >= waitTime)   //時間を超えたとき設置
                {
                    Instantiate(ResourcesManager.Instance.GetResourceScene("babel"), transform.position, transform.rotation);
                    putFlg = true;
                    moveFlg = false;
                    time = 0;
                }
            }

            else if (Input.GetButtonUp("BatuP2"))
            {
                time = 0;  //ばつが離れたとき
                moveFlg = false;
            }

        }
        else{

            time += Time.deltaTime;

            if (time >= interval)
            {
                Debug.Log("reload");
                putFlg = false;
                time = 0;
            }
        }
    }
}
