//<Summary>
//YutaKaseda
//16/2/19
//</Summary>
using UnityEngine;
using UnityEngine.VR;
using System.Collections;
using GameMainData;
using OnlineStatus;
using UnityEngine.Networking;

public class OnlineLevel : SingletonMonobehaviour<OnlineLevel> {

    public bool player2DConnected;

    public GameObject localPlayer { get; set; }
    public MainInterface localPlayerMainInterface { get; set; }

    [SerializeField]
    GameObject bossObject;

    [SerializeField]
    GameObject centerTowerUI;

    void Awake(){

        player2DConnected = false;

        GameData.onlineState = E_ONLINE_STATE.NETWORK_CONNECT;
        ResourcesManager.Instance.ResourcesLoadScene("Online");

    }

    public void VRDeviceEnabled(){

        VRSettings.enabled = true;
        InputTracking.Recenter();

    }

    void Update(){

        switch(GameData.onlineState){

            case E_ONLINE_STATE.NETWORK_CONNECT:

                if (player2DConnected)
                    ChangeNextState();

                break;

            case E_ONLINE_STATE.GAME_START_WAIT:
                localPlayerMainInterface.IMain();
                ChangeNextState();

                break;

            case E_ONLINE_STATE.GAME_PLAY:
                localPlayerMainInterface.IMain();
                bossObject.GetComponent<BossMk2>().Main();

                break;

            case E_ONLINE_STATE.GAME_CLEAR:
                localPlayerMainInterface.IMain();


                break;

            case E_ONLINE_STATE.NETWORK_DISCONNECT:

                break;

            default:
                break;

        }
    }

    public void ChangeNextState(){

        E_ONLINE_STATE prevState = GameData.onlineState;

        switch (prevState){

            case E_ONLINE_STATE.NETWORK_CONNECT:
                Debug.Log(localPlayer);
                localPlayer.GetComponent<NetworkSetup>().SetupLocalPlayer();
                localPlayerMainInterface = localPlayer.GetComponent<MainInterface>();
                GameData.onlineState = E_ONLINE_STATE.GAME_START_WAIT;

                break;

            case E_ONLINE_STATE.GAME_START_WAIT:

                StartCoroutine(GameStartCountDown());
                //bossObject = Instantiate(ResourcesManager.Instance.GetResourceScene("Boss"), transform.position, transform.rotation) as GameObject;
                //NetworkServer.Spawn(bossObject);
                bossObject = GameObject.FindWithTag("Boss");
                bossObject.GetComponent<BossMk2>().Init();
                GameData.onlineState = E_ONLINE_STATE.NONE;
                break;

            case E_ONLINE_STATE.GAME_PLAY:

                break;

            case E_ONLINE_STATE.GAME_CLEAR:

                break;

            default:

                break;
        }

    }

    IEnumerator GameStartCountDown(){

        int count = 3;

        while (count != 0){

            centerTowerUI.GetComponent<CountDownUI>().TextUpdate(count.ToString());
            count--;
            yield return new WaitForSeconds(1.0f);
        }

        centerTowerUI.GetComponent<CountDownUI>().TextUpdate("GO!");
        GameData.onlineState = E_ONLINE_STATE.GAME_PLAY;

        yield return new WaitForSeconds(3.0f);

        centerTowerUI.SetActive(false);

    }

}
