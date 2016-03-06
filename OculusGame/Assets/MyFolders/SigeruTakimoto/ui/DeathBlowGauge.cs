using UnityEngine;
using System.Collections;
using UnityEngine.UI;
// 2月~16日　瀧本　基礎　(GageUp、UseLaser)
// 2016/02/17 梅村 Text周りをちょいと修正
// 2016/02/19 梅村 全体的に見やすくなったかな？
// 2016/02/19 梅村 いらない所消去
// 2016/03/4 梅村 全体的に修正。UIの形を変えたため
// 2016/03/6 梅村 必殺技使用のための変更
public class DeathBlowGauge : MonoBehaviour {
	
	Slider deathBlowGaugeSlider;
	
	Image deathBlowGaugeImg2D;
	Image deathBlowGaugeImg3D;
	
	PlayerData2D playerData2D;
	[SerializeField]
	float gaugeMax;
	void Awake(){
		deathBlowGaugeImg2D = GameObject.Find ("DeathBlowValue2D").GetComponent<Image> ();
		deathBlowGaugeImg2D.fillAmount = 0;
		deathBlowGaugeImg3D = GameObject.Find("DeathBlowValue3D").GetComponent<Image>();
		deathBlowGaugeImg3D.fillAmount = 0;
		playerData2D = GameObject.FindWithTag("Player2D").GetComponent<PlayerData2D>();
		gaugeMax = 300f;
	}
	
	//必殺技のゲージをためる
	//２Dまたは３Dが敵を倒したとき
	public void GaugeUp(){
		if (deathBlowGaugeImg2D.fillAmount < 1f) {
			deathBlowGaugeImg2D.fillAmount += (1f / gaugeMax);
		}
		if (deathBlowGaugeImg3D.fillAmount < 1f){
			deathBlowGaugeImg3D.fillAmount += (1f / gaugeMax);
		}
		
		if (deathBlowGaugeImg2D.fillAmount >= 1f) {
			playerData2D.specialArts = true;
		}
	}
	//必殺技使った時
	//呼ぶだけ
	public void UseLaser(){
		deathBlowGaugeImg2D.fillAmount = 0;
		deathBlowGaugeImg3D.fillAmount = 0;
		playerData2D.specialArts = false;
	}
	
}
