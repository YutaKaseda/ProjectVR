using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BeaconUI : MonoBehaviour
{

    PlayerData2D playerdata;
    Slider ber;
    Image clearBer;
    float time;

    void Awake()
    {
        playerdata = GetComponent<PlayerData2D>();
        ResourcesManager.Instance.ResourcesLoadScene("Play");
        ber = GameObject.Find("WaitBer").GetComponent<Slider>();
        clearBer = GameObject.Find("Background").GetComponent<Image>();
        time = 0;
        clearBer.enabled = false;
    }

    public void BeaconPutUI()
    {
        if (playerdata.moveFlg == true)  //ばつが押されている間
        {
            clearBer.enabled = true;
            time += Time.deltaTime;
            ber.value += Time.deltaTime;

            if (time >= playerdata.waitTime)   //時間を超えたとき設置
            {
                clearBer.enabled = false;
                ber.value = 0;
                time = 0;
            }
        }

        else if (playerdata.moveFlg == false) //ばつが離れたとき
        {
            clearBer.enabled = false;
            ber.value = 0;
            time = 0;
        }

    }
}
