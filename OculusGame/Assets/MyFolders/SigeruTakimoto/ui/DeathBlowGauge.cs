using UnityEngine;
using System.Collections;
using UnityEngine.UI;
// 2月~16日　瀧本　基礎　(GageUp、UseLaser)
// 2016/02/17 梅村 Text周りをちょいと修正
// 2016/02/19 梅村 全体的に見やすくなったかな？
// 2016/02/19 梅村 いらない所消去
// 2016/03/4 梅村 全体的に修正。UIの形を変えたため
public class DeathBlowGauge : MonoBehaviour {

	Slider deathBlowGaugeSlider;

	Image deathBlowGaugeImg;
	void Awake(){
		deathBlowGaugeImg = GameObject.Find ("DeathBlowValue").GetComponent<Image> ();
		deathBlowGaugeImg.fillAmount = 0;
	}

	//必殺技のゲージをためる
	//２Dまたは３Dが敵を倒したとき
	public void GaugeUp(){
		if (deathBlowGaugeImg.fillAmount < 1f) {
			deathBlowGaugeImg.fillAmount += 0.004f;
		}
	}
	//必殺技使った時
	//呼ぶだけ
	public void UseLaser(){
		deathBlowGaugeImg.fillAmount = 0;
	}
	
}
