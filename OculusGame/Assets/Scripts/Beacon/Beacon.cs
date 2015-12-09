using UnityEngine;
using System.Collections;

public class Beacon : MonoBehaviour {

    public bool putFlg { get; private set; }
    public bool moveFlg { get; private set; }
    public float time { get; private set; }
    public float interval { get; private set; }
    public float waitTime { get; private set; }
    enum barrierState { OPEN, DELETE, STAY, IDLE }; //　barrierステータス、展開中、破壊、待機中
    barrierState barrierFlg;

    void Awake()
    {
        ResourcesManager.Instance.ResourcesLoadScene("Play");
        putFlg = false;
        time = 0;
        waitTime = 3;
        interval = 10;
        moveFlg = false;
        barrierFlg = barrierState.IDLE;
    }

    public void BeaconPut()
    {
        BarrierOpen();

        if (putFlg == false)
        {
            if (Input.GetButton("BatuP2"))  //ばつが押されている間
            {
                time += Time.deltaTime;
                moveFlg = true;
                if (barrierFlg == barrierState.IDLE)
                {
                    barrierFlg = barrierState.OPEN;
                }

                if (time >= waitTime)   //時間を超えたとき設置
                {
                    Instantiate(ResourcesManager.Instance.GetResourceScene("babel"), transform.position, transform.rotation);
                    putFlg = true;
                    moveFlg = false;
                    time = 0;
                    barrierFlg = barrierState.DELETE;
                }
            }

            else if (Input.GetButtonUp("BatuP2"))
            {
                time = 0;  //ばつが離れたとき
                moveFlg = false;
                barrierFlg = barrierState.DELETE;
            }

        }
        else{

            time += Time.deltaTime;
            barrierFlg = barrierState.IDLE;

            if (time >= interval)
            {
                Debug.Log("reload");
                putFlg = false;
                time = 0;
            }
        }
    }

    public void BarrierOpen()
    {
        switch (barrierFlg)
        {
            case barrierState.DELETE:
                Destroy(GameObject.Find("barrier(Clone)"));
                barrierFlg = barrierState.IDLE;
                break;
            case barrierState.OPEN:
                Instantiate(ResourcesManager.Instance.GetResourceScene("barrier"), transform.position, transform.rotation);
                barrierFlg = barrierState.STAY;
                break;
            case barrierState.STAY:

                break;
            default:
                break;
        }
    }

}
