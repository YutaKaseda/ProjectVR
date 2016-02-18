using UnityEngine;
using System.Collections;
using UnityEngine.UI;
// 2月~16日　瀧本　基礎　(GageUp、UseLaser)
// 2016/02/17 梅村 Text周りをちょいと修正
// 2016/02/19 梅村 全体的に見やすくなったかな？
public class DeathBlowGauge : MonoBehaviour {

	Slider deathBlowGaugeSlider;
	Text deathBlowText;
	int laser2D;//必殺技

	void Awake(){
		deathBlowGaugeSlider = GameObject.Find ("DeathBlow").GetComponent<Slider> ();
		deathBlowText = GameObject.Find ("DeathBlowGage").GetComponent<Text>();
		deathBlowGaugeSlider.maxValue = 250;
		laser2D = 0;
	}

	//必殺技のゲージをためる
	//２Dまたは３Dが敵を倒したとき
	public void GaugeUp(){
		deathBlowGaugeSlider.value += 1;
		if (deathBlowGaugeSlider.value >= 250) {
			laser2D +=1;
			deathBlowGaugeSlider.value = 0;
		}
		deathBlowTextDraw ();
	}
	//必殺技使った時
	//呼ぶだけ
	public void UseLaser(){
		laser2D -= 1;
		deathBlowTextDraw ();
	}

	public void deathBlowTextDraw(){
		deathBlowText.text = "Laser:"+laser2D;
	}
}
