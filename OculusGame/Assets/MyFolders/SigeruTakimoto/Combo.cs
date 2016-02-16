using UnityEngine;
using System.Collections;
using UnityEngine.UI;
// 2月~16日　瀧本　全部

public class Combo : MonoBehaviour {
	
	[SerializeField]
	PlayerData playerData;
	[SerializeField]
	PlayerData2D playerData2D;
	[SerializeField]
	Lifes2D lifes;
	[SerializeField]
	Text comboText;
	[SerializeField]
	SubScore subscore;
	//追加score保存
	int upScore;
	int Base;

	void Awake(){
		comboText.text=playerData.killCombo+" ";
	}

	//敵にを倒したとき
	public void ComboUp(){
		playerData.killCombo += 1;
		if (playerData.killCombo % 50 == 0) {
			subscore.ScoreUp();
			if (playerData.killCombo % 100 == 0) {
				playerData2D.weaponLevel += 1;
			}
			if (playerData.killCombo % 500 == 0) {
				playerData2D.lifes += 1;
				lifes.LifesDraw ();
			}
		}
		comboText.text = playerData.killCombo + " ";
	}

	//コンボ初期化
	//２Dが死んだとき呼ぶ
	public void ComboDown(){
		playerData.killCombo = 0;
		comboText.text = playerData.killCombo + " ";
	}
}

