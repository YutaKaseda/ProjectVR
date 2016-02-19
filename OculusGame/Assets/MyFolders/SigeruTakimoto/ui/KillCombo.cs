using UnityEngine;
using System.Collections;
using UnityEngine.UI;
// 2月~16日　瀧本　comboUp、Down
// 2016/02/17 梅村 SubScore.cs -> scoreUpAnim.csに名前変更に伴う変更
// 2016/02/19 梅村 全体的に見やすくなったかな？
public class KillCombo : MonoBehaviour {
	
	PlayerData2D playerData2D;
	Lifes2D lifes2D;
	ScoreUpAnim scoreUpAnim;
	Text comboText2D;
	Text comboText3D;
	
	void Awake(){
		playerData2D = GameObject.FindWithTag("Player2D").GetComponent<PlayerData2D>();
		lifes2D = 	   gameObject.GetComponent<Lifes2D>();
		scoreUpAnim =  gameObject.GetComponent<ScoreUpAnim>();
		comboText2D =  GameObject.Find("Combo2D").GetComponent<Text>();
		comboText3D =  GameObject.Find("Combo3D").GetComponent<Text>();
		ComboDraw ();
	}

	//敵にを倒したとき呼ぶ
	public void ComboUp(){
		playerData2D.killCombo += 1;

		if (playerData2D.killCombo % 50 == 0) {
			scoreUpAnim.ScoreUp (playerData2D.killCombo);
		}
		if (playerData2D.killCombo % 100 == 0) {
			playerData2D.weaponLevel += 1;
		}
		if (playerData2D.killCombo % 500 == 0) {
			playerData2D.lifes += 1;
			lifes2D.LifesDraw ();
		}

		ComboDraw ();
	}

	//コンボ初期化
	//２Dが死んだとき呼ぶ
	public void ComboReset(){
		playerData2D.killCombo = 0;
		ComboDraw ();
	}

	public void ComboDraw(){
		comboText2D.text = playerData2D.killCombo + " ";
		comboText3D.text = playerData2D.killCombo + " ";
	}
}

