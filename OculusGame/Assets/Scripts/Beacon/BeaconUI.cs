using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BeaconUI : MonoBehaviour
{

    Beacon playerBeacon;
    Slider ber;
    Image clearBer;
    float time;
    enum barrierState { OPEN,DALETE,STAY }; //　barrierステータス、展開中、破壊、待機中
    barrierState barrierFlg;

    void Awake()
    {
        ResourcesManager.Instance.ResourcesLoadScene("Play");
        playerBeacon = GetComponent<Beacon>();
        ber = GameObject.Find("WaitBer").GetComponent<Slider>();
        clearBer = GameObject.Find("Background").GetComponent<Image>();
        time = 0;
        clearBer.enabled = false;
        barrierFlg = barrierState.STAY;
    }

    public void BeaconPutUI()
    {
        if (playerBeacon.moveFlg == true)  //ばつが押されている間
        {
            clearBer.enabled = true;
            time += Time.deltaTime;
            ber.value += Time.deltaTime;

            if (time >= playerBeacon.waitTime)   //時間を超えたとき設置
            {
                clearBer.enabled = false;
                ber.value = 0;
                time = 0;
                barrierFlg = barrierState.DALETE;
            }
        }

        else if (playerBeacon.moveFlg == false) //ばつが離れたとき
        {
            clearBer.enabled = false;
            ber.value = 0;
            time = 0;
            barrierFlg = barrierState.DALETE;
        }

    }

    public void BarrierOpen()
    {
        if (barrierFlg == barrierState.STAY)
        {
            Instantiate(ResourcesManager.Instance.GetResourceScene("barrier"), transform.position, transform.rotation);
            barrierFlg = barrierState.OPEN;
        }
    }
}
