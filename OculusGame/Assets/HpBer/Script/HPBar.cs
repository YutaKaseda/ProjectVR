using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HPBar : MonoBehaviour {

[SerializeField]
Slider Slider;
	
	void Awake(){
		Slider.maxValue= Player_Hp;
	}
	public float Player_Hp;
	void Update () {
		Player_Hp = HpBar(Player_Hp);
			}
	float HpBar(float Hp){
		if(Hp <Slider.minValue) {
			// 0になったら最大に戻す
			Hp = Slider.maxValue;
		}
		// HPゲージに値を設定
		Slider.value = Hp;
			return Hp;
	}
}