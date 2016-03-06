//2016/02/18 梅村 UIの大本を作成。更新したいUIの名前と、値があれば正しい値を入れることでアクセスしてくれる
// 2016/02/19 梅村 全体的に見やすくなったかな？
// 2016/03/6 梅村 UseSpecialArts(必殺技)追加
using UnityEngine;
using System.Collections;

public class AllUI : MonoBehaviour {
	
	KillCombo killCombo;
	Score score;
	DeathBlowGauge deathBlowGauge;
	Lifes2D lifes2D;
	
	// Use this for initialization
	void Awake () {
		killCombo = GetComponent<KillCombo>();
		score = GetComponent<Score>();
		deathBlowGauge = GetComponent<DeathBlowGauge>();
		lifes2D = GetComponent<Lifes2D>();
	}
	
	public void UiUpdate(string uiName,int value){
		switch (uiName) {
		case "ScoreUp":
			score.ScorePlus(value);
			break;
		case "ComboUp":
			killCombo.ComboUp ();
			break;
		case "ComboReset":
			killCombo.ComboReset();
			break;
		case "DeathBlowGaugeUp":
			deathBlowGauge.GaugeUp();
			break;
		case "UseSpecialArts":
			deathBlowGauge.UseLaser();
			break;
		case "Lifes2D":
			lifes2D.ReduceLife ();
			break;
		default:
			Debug.LogError("UIの指定ミス");
			break;
		}
	}
	
	
}
