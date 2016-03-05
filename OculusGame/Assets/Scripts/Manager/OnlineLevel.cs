//<Summary>
//YutaKaseda
//16/2/19
//16/3/6 リザルトへ飛ぶ
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

    [SerializeField]
    PlayerData playerData;

    [SerializeField]
    PlayerData2D playerData2D;

    [SerializeField]
    AudioClip bossBGM;

    void Awake(){

        GameData.onlineState = E_ONLINE_STATE.NETWORK_CONNECT;
        ResourcesManager.Instance.ResourcesLoadScene("OnLine");
        PlayerPrefs.SetInt("NowScore", 0);
        PlayerPrefs.SetInt("NowTopKill", 0);
        PlayerPrefs.SetInt("Now2DLife", 0);

        //bossMain.Init();

    }

    public void VRDeviceEnabled(){

        VRSettings.enabled = true;
        //InputTracking.Recenter();

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
                //bossMain.Main();

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

    public void ChangeBossBGM()
    {
        bgmAudioSource.Stop();
        bgmAudioSource.clip = bossBGM;
        bgmAudioSource.Play();
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

		PlayerPrefs.SetInt("NowScore", playerData.score);
        PlayerPrefs.SetInt("Now2DLife", playerData2D.lifes);
        if (PlayerPrefs.GetInt("NowTopKill") < playerData2D.killCombo)
            PlayerPrefs.SetInt("NowTopKill", playerData2D.killCombo);
		
		Application.LoadLevelAsync("Result"); //リザルトにとびます
    }

}
