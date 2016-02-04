using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections;
using GameMainData;

public class BGMVolume : MonoBehaviour {

	public AudioMixer mixer;
	public Slider BGMslider;
	public float BGMvol;
	
	//Sliderの取得・初期化
	//AudioMixerの取得
	void Awake(){
		BGMslider = GetComponent<Slider>();
		BGMslider.value = 0.0f;
		mixer.SetFloat("BGMVolume", BGMvol);
	}

	//AudioMixerの更新
	void Update(){

		if (BGMslider.value != BGMvol) {
			BGMvol = BGMslider.value;
			mixer.SetFloat ("BGMVolume", BGMvol);
		}
		if(Input.GetKeyUp(KeyCode.RightShift) || Input.GetButtonUp("BatuP1")){
			GameData.nextState = OfflineStatus.E_OFFLINE_STATE.MENU;
		}
		if(Input.GetKey(KeyCode.LeftArrow) || Input.GetButton("L1P1")){
			BGMslider.value--;
		}
		if(Input.GetKey(KeyCode.RightArrow) || Input.GetButton("R1P1")){
			BGMslider.value++;
		}
	}
}