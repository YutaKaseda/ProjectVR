﻿//<Summary>
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

    [SerializeField]
    GameObject OculusPlayer;
    [SerializeField]
    MainInterface OculusPlayerMainInterface;

    [SerializeField]
    GameObject SecondPlayer;
    [SerializeField]
    MainInterface SecondPlayerMainInterface;

    [SerializeField]
    GameObject bossObject;
    [SerializeField]
    BossMk2 bossMain;

    [SerializeField]
    GameObject centerTowerUI;

    [SerializeField]
    AudioSource bgmAudioSource;

    void Awake(){

        GameData.onlineState = E_ONLINE_STATE.NETWORK_CONNECT;
        ResourcesManager.Instance.ResourcesLoadScene("OnLine");

        bossMain.Init();

    }

    public void VRDeviceEnabled(){

        VRSettings.enabled = true;
        InputTracking.Recenter();

    }

    void Update(){

        switch(GameData.onlineState){

            case E_ONLINE_STATE.NETWORK_CONNECT:

                ChangeNextState();

                break;

            case E_ONLINE_STATE.GAME_START_WAIT:
                OculusPlayerMainInterface.IMain();
                SecondPlayerMainInterface.IMain();
                ChangeNextState();

                break;

            case E_ONLINE_STATE.GAME_PLAY:
                OculusPlayerMainInterface.IMain();
                SecondPlayerMainInterface.IMain();
                bossMain.Main();

                break;

            case E_ONLINE_STATE.GAME_CLEAR:
                OculusPlayerMainInterface.IMain();
                SecondPlayerMainInterface.IMain();


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
                
                GameData.onlineState = E_ONLINE_STATE.GAME_START_WAIT;

                break;

            case E_ONLINE_STATE.GAME_START_WAIT:

                StartCoroutine(GameStartCountDown());
             
                GameData.onlineState = E_ONLINE_STATE.NONE;
                break;

            case E_ONLINE_STATE.GAME_PLAY:

                StartCoroutine(GameClearCountDown());

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
            SoundPlayer.Instance.PlaySoundEffect("push", 1.0f);
            yield return new WaitForSeconds(1.0f);
        }

        bgmAudioSource.Play();
        centerTowerUI.GetComponent<CountDownUI>().TextUpdate("GO!");
        GameData.onlineState = E_ONLINE_STATE.GAME_PLAY;

        yield return new WaitForSeconds(3.0f);

        centerTowerUI.SetActive(false);

    }

    IEnumerator GameClearCountDown()
    {

        centerTowerUI.SetActive(true);

        centerTowerUI.GetComponent<CountDownUI>().TextUpdate("CLEAR!");
        GameData.onlineState = E_ONLINE_STATE.GAME_CLEAR;
        
        yield return new WaitForSeconds(7.0f);

        Application.LoadLevelAsync("network_offline"); 
        
        centerTowerUI.SetActive(false);

    }

}
