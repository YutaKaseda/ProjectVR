using UnityEngine;
using System.Collections;
using UnityEngine.UI;
// 2月~16日　瀧本　comboUp、Down
// 2016/02/17 梅村 SubScore.cs -> scoreUpAnim.csに名前変更に伴う変更

public class KillCombo : MonoBehaviour {

	[SerializeField]
	PlayerData2D playerData2D;
	[SerializeField]
	Lifes2D lifes;
	Text comboText;
	[SerializeField]
	ScoreUpAnim scoreUpAnim;
	//追加score保存
	int upScore;
	int Base;

	void Awake(){
		comboText = GetComponent<Text>();
		comboText.text=playerData2D.killCombo+" ";
	}

	//敵にを倒したとき呼ぶ
	public void ComboUp(){
		playerData2D.killCombo += 50;
		if (playerData2D.killCombo % 50 == 0) {
			scoreUpAnim.ScoreUp();
			if (playerData2D.killCombo % 100 == 0) {
				playerData2D.weaponLevel += 1;
			}
			if (playerData2D.killCombo % 500 == 0) {
				playerData2D.lifes += 1;
				lifes.LifesDraw ();
			}
		}
		comboText.text = playerData2D.killCombo + " ";
	}

	//コンボ初期化
	//２Dが死んだとき呼ぶ
	public void ComboReset(){
		playerData2D.killCombo = 0;
		comboText.text = playerData2D.killCombo + " ";
	}
}

