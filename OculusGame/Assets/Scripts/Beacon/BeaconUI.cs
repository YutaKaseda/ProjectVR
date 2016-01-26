using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BeaconUI : MonoBehaviour
{

    Beacon playerBeacon;
    Slider ber;
    Image clearBer;
    float time;
    enum barrierState { OPEN,DELETE,STAY,IDLE }; //　barrierステータス、展開中、破壊、待機中
    barrierState barrierFlg;
    GameObject barrier;

    void Awake(){

        playerBeacon = GetComponent<Beacon>();
        ber = GameObject.Find("WaitBer").GetComponent<Slider>();
        clearBer = GameObject.Find("Background").GetComponent<Image>();
        time = 0;
        clearBer.enabled = false;
        barrierFlg = barrierState.IDLE;
    }

    public void BeaconPutUI()
    {
        if (playerBeacon.moveFlg == true)  //ばつが押されている間
        {
            clearBer.enabled = true;
            time += Time.deltaTime;
            ber.value += Time.deltaTime;
            if (barrierFlg == barrierState.IDLE) {
                barrierFlg = barrierState.OPEN;
            }

            if (time >= playerBeacon.waitTime)   //時間を超えたとき設置
            {
                clearBer.enabled = false;
                ber.value = 0;
                time = 0;
                barrierFlg = barrierState.DELETE;
            }
        }

        else if (playerBeacon.moveFlg == false) //ばつが離れたとき
        {
            clearBer.enabled = false;
            ber.value = 0;
            time = 0;
            barrierFlg = barrierState.DELETE;
        }

    }

    public void BarrierOpen()
    {
        switch (barrierFlg)
        {
            case barrierState.DELETE:
                if (GameObject.Find("barrier") != null)
                    Destroy(barrier);
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
