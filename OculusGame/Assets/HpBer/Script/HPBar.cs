using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HPBar : MonoBehaviour {


Slider Slider;

[^
void Start () {
}

	void Awake(){
		// スライダーを取得する
		Slider = GameObject.Find("Slider").GetComponent<Slider>();





		//他のscriptから参照
		//Player = GetComponent<Player>();
		//Player.Hp=Player.Hp;

		//Player.DoSomething();

	


	}

	public float Player_Hp=60;


	void Update () {


			Player_Hp -=1f;
	
		Player_Hp = HpBar(Player_Hp);




	}

	float HpBar(float Hp){
		if(Hp < Slider.minValue) {
			// 0になったら最大に戻す
			Hp = Slider.maxValue;
		}
		
		// HPゲージに値を設定
		Slider.value = Hp;

		return Hp;
	}

}