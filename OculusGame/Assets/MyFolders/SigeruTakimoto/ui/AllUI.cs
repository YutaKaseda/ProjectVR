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
		killCombo = GameObject.Find("Combo").GetComponent<KillCombo>();
		score = GameObject.Find("Score").GetComponent<Score>();
		deathBlowGage = GameObject.Find("DeathBlowGage").GetComponent<DeathBlowGage>();
		lifes2D = GameObject.Find("Lifes2DText").GetComponent<Lifes2D>();
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
