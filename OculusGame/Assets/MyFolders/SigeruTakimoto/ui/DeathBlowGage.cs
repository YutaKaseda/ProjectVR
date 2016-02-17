using UnityEngine;
using System.Collections;
using UnityEngine.UI;
// 2月~16日　瀧本　基礎　(GageUp、UseLaser)
// 2016/02/17 梅村 Text周りをちょいと修正
public class DeathBlowGage : MonoBehaviour {

	Slider deathBlowGage;
	int killGage;
	int laser2D;
	Text deathBlowText;

	void Awake(){
		deathBlowGage = GameObject.Find ("DeathBlow").GetComponent<Slider> ();
		deathBlowText = gameObject.GetComponent<Text>();
		deathBlowGage.maxValue = 250;
		killGage = 0;
		//必殺技
		laser2D = 0;
	}

	//必殺技のゲージをためる
	//２Dまたは３Dが敵を倒したとき
	public void GageUp(){
		killGage += 1;
			if (killGage >= 250) {
				laser2D +=1;
				killGage = 0;
			}
		deathBlowGage.value = killGage;
		deathBlowText.text = "Laser:"+laser2D;
	}
	//必殺技使った時
	//呼ぶだけ
	public void UseLaser(){
		laser2D -= 1;
		deathBlowText.text = "Laser:"+laser2D;
	}
}
