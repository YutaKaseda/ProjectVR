using UnityEngine;
using System.Collections;
using BarrierStatus;

public class Beacon : MonoBehaviour {

	/*//new  newは石田の作り途中なんで今は無視で
	public GameObject babel;
	public int number = 1;
	*/

    PlayerData2D playerData;

    void Awake()
    {
        playerData = GetComponent<PlayerData2D>();
        ResourcesManager.Instance.ResourcesLoadScene("Play");
        playerData.putFlg = false;
        playerData.time = 0;
        playerData.waitTime = 3;
        playerData.interval = 5;
        playerData.penaltyTime = 2;
        playerData.moveFlg = false;
        playerData.penaltyFlg = false;
        playerData.barrierFlg = BarrierState.E_IDLE;
    }

    public void BeaconPut()
    {
        BarrierOpen();

        if (playerData.putFlg == false)
        {
            if (Input.GetButton("BatuP2"))  //ばつが押されている間
            {
                playerData.time += Time.deltaTime;
                playerData.moveFlg = true;
                if (playerData.barrierFlg == BarrierState.E_IDLE)
                {
                    playerData.barrierFlg = BarrierState.E_OPEN;
                }

                if (playerData.time >= playerData.waitTime)   //時間を超えたとき設置
                {
					/*//new
					ResourcesManager.Instance.GetResourceScene("babel").name = "Babel" + number;
					babel = (GameObject)Instantiate(ResourcesManager.Instance.GetResourceScene("babel"), transform.position, transform.rotation);
					babel.name = ResourcesManager.Instance.GetResourceScene("babel").name;
					number++;
					*/
					Instantiate(ResourcesManager.Instance.GetResourceScene("babel"), transform.position, transform.rotation);
                    playerData.putFlg = true;
                    playerData.moveFlg = false;
                    playerData.time = 0;
                    playerData.barrierFlg = BarrierState.E_DELETE;
                }
            }

            else if (Input.GetButtonUp("BatuP2"))  //ばつが離れたとき
            {
                playerData.time = 0;
                playerData.moveFlg = false;
                playerData.putFlg = true;
                playerData.penaltyFlg = true;
                playerData.barrierFlg = BarrierState.E_DELETE;
            }

        }
        else{

            playerData.time += Time.deltaTime;
            playerData.barrierFlg = BarrierState.E_IDLE;

            if (playerData.time >= playerData.interval) //インターバル時間を超えたら
            {
                playerData.putFlg = false;
                playerData.time = 0;
            }
            if (playerData.time >= playerData.penaltyTime && playerData.penaltyFlg == true) //ペナルティ時間を超えたら
            {
                playerData.putFlg = false;
                playerData.penaltyFlg = false;
                playerData.time = 0;
            }
        }
    }

    public void BarrierOpen()
    {
        switch (playerData.barrierFlg)
        {
            case BarrierState.E_DELETE:
                Destroy(GameObject.Find("barrier(Clone)"));
                Instantiate(ResourcesManager.Instance.GetResourceScene("Barrierbreak"), transform.position, transform.rotation);
                playerData.barrierFlg = BarrierState.E_IDLE;
                break;
            case BarrierState.E_OPEN:
                Instantiate(ResourcesManager.Instance.GetResourceScene("barrier"), transform.position, transform.rotation);
                playerData.barrierFlg = BarrierState.E_STAY;
                break;
            case BarrierState.E_STAY:
                break;
            default:
                break;
        }
    }

}
