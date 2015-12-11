using UnityEngine;
using UnityEngine.VR;
using System.Collections;
using System.Collections.Generic;
using OfflineStatus;
using GameMainData;

public class OfflineLevel : SingletonMonobehaviour<OfflineLevel> {

    void Awake()
    {
        GameData.offlineState = E_OFFLINE_STATE.TITLE;

        VRSettings.enabled = false;

        ResourcesManager.Instance.ResourcesLoadAllScene();
        ResourcesManager.Instance.ResourcesLoadScene("Offline");

    }

    void Update()
    {
        switch (GameData.offlineState)
        {
            case E_OFFLINE_STATE.TITLE:
                break;

            case E_OFFLINE_STATE.MENU:
                break;

            case E_OFFLINE_STATE.OPTION:
                break;

            case E_OFFLINE_STATE.RANKING:
                break;

            case E_OFFLINE_STATE.CUSTOMIZE:
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
    }
}
