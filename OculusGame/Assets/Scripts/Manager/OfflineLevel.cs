using UnityEngine;
using UnityEngine.VR;
using System.Collections;
using System.Collections.Generic;
using OfflineStatus;
using GameMainData;

public class OfflineLevel : SingletonMonobehaviour<OfflineLevel> {
	GameObject[] offlineSceneObj = new GameObject[5];

	static int sTitle = 0;
	static int sMenu = 1;
	static int sOption = 2;
	static int sRanking = 3;
	static int sCustmize = 4;
    void Awake()
    {
		GameData.offlineState = E_OFFLINE_STATE.NULL;
		GameData.nextState = E_OFFLINE_STATE.TITLE;

        VRSettings.enabled = false;


		ResourcesManager.Instance.ResourcesLoadAllScene();
		ResourcesManager.Instance.ResourcesLoadScene("Offline");

		Init ();
	}

    void Update()
    {
		Debug.Log ("offlineState : " + GameData.offlineState);
		Debug.Log ("nextState : " + GameData.nextState);
        switch (GameData.offlineState)
        {
            case E_OFFLINE_STATE.TITLE:
			if(Input.GetKeyUp(KeyCode.Return) || Input.GetButtonUp("MaruP1")){
				GameData.nextState = E_OFFLINE_STATE.MENU;
			}
            break;

            case E_OFFLINE_STATE.MENU:

			break;

            case E_OFFLINE_STATE.OPTION:
			if(Input.GetKeyUp(KeyCode.RightShift)){
				GameData.nextState = E_OFFLINE_STATE.MENU;
			}
			break;

            case E_OFFLINE_STATE.RANKING:

			break;

            case E_OFFLINE_STATE.CUSTOMIZE:

			break;

            case E_OFFLINE_STATE.NETWORK_SETUP:
                break;

            case E_OFFLINE_STATE.NETWORK_CONNECTING:
                break;

            default:
                Debug.LogError(GameData.offlineState + "is nothing");
                break;
        }
		CheckStateChange ();
    }

	void CheckStateChange(){

		if (GameData.nextState != E_OFFLINE_STATE.NULL) {

			switch (GameData.nextState)
			{
			case E_OFFLINE_STATE.TITLE:
				offlineSceneObj[sTitle].SetActive(true);
				break;
				
			case E_OFFLINE_STATE.MENU:
				offlineSceneObj[sMenu].SetActive(true);
				break;
				
			case E_OFFLINE_STATE.OPTION:
				offlineSceneObj[sOption].SetActive(true);
				break;
				
			case E_OFFLINE_STATE.RANKING:
				offlineSceneObj[sRanking].SetActive(true);
				break;
				
			case E_OFFLINE_STATE.CUSTOMIZE:
				offlineSceneObj[sCustmize].SetActive(true);
				break;
				
			case E_OFFLINE_STATE.NETWORK_SETUP:
				Instantiate(ResourcesManager.Instance.GetResourceAllScene("NetworkManager"), Vector3.zero, Quaternion.Euler(Vector3.zero));
				GameData.offlineState = E_OFFLINE_STATE.NETWORK_CONNECTING;
				break;
				
			case E_OFFLINE_STATE.NETWORK_CONNECTING:
				break;
				
			default:
				Debug.LogError(GameData.offlineState + "is nothing");
				break;
			}

			switch (GameData.offlineState)
			{
			case E_OFFLINE_STATE.TITLE:
				offlineSceneObj[sTitle].SetActive(false);
				break;
				
			case E_OFFLINE_STATE.MENU:
				offlineSceneObj[sMenu].SetActive(false);
				break;
				
			case E_OFFLINE_STATE.OPTION:
				offlineSceneObj[sOption].SetActive(false);
				break;
				
			case E_OFFLINE_STATE.RANKING:
				offlineSceneObj[sRanking].SetActive(false);
				break;
				
			case E_OFFLINE_STATE.CUSTOMIZE:
				offlineSceneObj[sCustmize].SetActive(false);
				break;
				
			default:
				Debug.LogError(GameData.offlineState + "is nothing");
				break;
			}

			GameData.offlineState = GameData.nextState;
			GameData.nextState = E_OFFLINE_STATE.NULL;

		}
	}

	void Init(){
		offlineSceneObj[sTitle] = Instantiate(ResourcesManager.Instance.GetResourceScene("Title"), Vector3.zero, Quaternion.Euler(Vector3.zero)) as GameObject;
		offlineSceneObj[sMenu] = Instantiate(ResourcesManager.Instance.GetResourceScene("MainMenu"), Vector3.zero, Quaternion.Euler(Vector3.zero)) as GameObject;
		offlineSceneObj[sOption] = Instantiate(ResourcesManager.Instance.GetResourceScene("Option"), Vector3.zero, Quaternion.Euler(Vector3.zero)) as GameObject;
		offlineSceneObj[sRanking] = Instantiate(ResourcesManager.Instance.GetResourceScene("Ranking"), Vector3.zero, Quaternion.Euler(Vector3.zero)) as GameObject;
		offlineSceneObj[sCustmize] = Instantiate(ResourcesManager.Instance.GetResourceScene("Garage"), Vector3.zero, Quaternion.Euler(Vector3.zero)) as GameObject;

		for(int i = 0;i < 5;i++){
			offlineSceneObj [i].SetActive (false);
		}
	}
}
