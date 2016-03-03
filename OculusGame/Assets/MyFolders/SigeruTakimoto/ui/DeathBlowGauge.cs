using UnityEngine;
using System.Collections;
using UnityEngine.UI;
// 2月~16日　瀧本　基礎　(GageUp、UseLaser)
// 2016/02/17 梅村 Text周りをちょいと修正
// 2016/02/19 梅村 全体的に見やすくなったかな？
// 2016/02/19 梅村 いらない所消去
public class DeathBlowGauge : MonoBehaviour {

	Slider deathBlowGaugeSlider;

	void Awake(){
		deathBlowGaugeSlider = GameObject.Find ("DeathBlow").GetComponent<Slider> ();
		deathBlowGaugeSlider.maxValue = 250;
	}

	//必殺技のゲージをためる
	//２Dまたは３Dが敵を倒したとき
	public void GaugeUp(){
		if (deathBlowGaugeSlider.value < 250) {
			deathBlowGaugeSlider.value += 1;
		}
	}
	//必殺技使った時
	//呼ぶだけ
	public void UseLaser(){
		deathBlowGaugeSlider.value = 0;
	}
	
}
