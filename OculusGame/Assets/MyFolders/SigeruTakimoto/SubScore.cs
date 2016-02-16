using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// 2月~16日　瀧本　基礎（ScoreUｐ、AnimEnd）

public class SubScore : MonoBehaviour {

	[SerializeField]
	PlayerData PlayerData;
	[SerializeField]
	Animator subScoreAnimation;
	[SerializeField]
	Text subScore;
	[SerializeField]
	Score score;
	int upScore;
	//追加scoreの変動するための変数
	int killLevel;

	void Awake(){
		subScoreAnimation.enabled = false;
		subScore.enabled = false;
		killLevel = 0;
	}
	//加算点数の追加
	//呼べば動く
	public void ScoreUp(){
		killLevel = PlayerData.killCombo / 50;
		subScore.enabled = true;
		subScoreAnimation.enabled = true;
		subScoreAnimation.SetBool("subScore", true );
		upScore = 5000 * killLevel * killLevel * killLevel;
		subScore.text = "+"+upScore +"点"; 
	}
	
	//アニメーション終わったら勝手に呼ばれる
	public void AnimEnd(){
		subScoreAnimation.SetBool("subScore", false );
		subScoreAnimation.enabled = false;
		subScore.enabled = false;
		PlayerData.score += upScore;
		score.ScoreDraw ();
	}
}

