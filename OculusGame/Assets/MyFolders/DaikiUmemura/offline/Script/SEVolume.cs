using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections;

public class SEVolume : MonoBehaviour {
	
	public AudioMixer mixer;
	public Slider SEslider;
	public float SEvol;
	
	//Sliderの取得・初期化
	//AudioMixerの取得
	void Awake(){
		SEslider = GetComponent<Slider>();
		SEslider.value = 0.0f;
		mixer.SetFloat("SEVolume", SEvol);
	}
	
	//AudioMixerの更新
	void Update(){
		if (SEslider.value != SEvol) {
			SEvol = SEslider.value;
			mixer.SetFloat ("SEVolume", SEvol);
		}
		if(Input.GetKey(KeyCode.Z) || Input.GetButton("L2P1")){
			SEslider.value--;
		}
		if(Input.GetKey(KeyCode.X) || Input.GetButton("R2P1")){
			SEslider.value++;
		}
	}
}