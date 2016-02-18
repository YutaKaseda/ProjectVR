//2016/02/18 梅村 UIの大本を作成。更新したいUIの名前と、値があれば正しい値を入れることでアクセスしてくれる

using UnityEngine;
using System.Collections;

public class AllUI : MonoBehaviour {
	[SerializeField]
	KillCombo killCombo;
	[SerializeField]
	Score score;
	[SerializeField]
	DeathBlowGage deathBlowGage;
	[SerializeField]
	Lifes2D lifes2D;


	// Use this for initialization
	void Awake () {
		killCombo = GetComponent<KillCombo>();
		score = GetComponent<Score>();
		deathBlowGage = GetComponent<DeathBlowGage>();
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
		case "DeathBlowGageUp":
			deathBlowGage.GageUp();
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
