using UnityEngine;
using System.Collections;

public class Beacon : MonoBehaviour {

    public bool putFlg { get; private set; }
    public bool moveFlg { get; private set; }
    public bool penaltyFlg { get; private set; }
    public float time { get; private set; }
    public float interval { get; private set; } //ビーコンを置いた後のインターバル
    public float waitTime { get; private set; } //ビーコンを置くのに必要な時間
    public float penaltyTime { get; private set; } //ビーコンを置いているときにボタンを離した時のペナルティタイム
    enum barrierState { OPEN, DELETE, STAY, IDLE }; //　barrierステータス　展開、破壊、展開中、待機中
    barrierState barrierFlg;

    void Awake()
    {
        ResourcesManager.Instance.ResourcesLoadScene("Play");
        putFlg = false;
        time = 0;
        waitTime = 3;
        interval = 5;
        penaltyTime = 2;
        moveFlg = false;
        penaltyFlg = false;
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

            else if (Input.GetButtonUp("BatuP2"))  //ばつが離れたとき
            {
                time = 0;
                moveFlg = false;
                putFlg = true;
                penaltyFlg = true;
                barrierFlg = barrierState.DELETE;
            }

        }
        else{

            time += Time.deltaTime;
            barrierFlg = barrierState.IDLE;

            if (time >= interval) //インターバル時間を超えたら
            {
                putFlg = false;
                time = 0;
            }
            if (time >= penaltyTime && penaltyFlg == true) //ペナルティ時間を超えたら
            {
                putFlg = false;
                penaltyFlg = false;
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
                Instantiate(ResourcesManager.Instance.GetResourceScene("Barrierbreak"), transform.position, transform.rotation);
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
