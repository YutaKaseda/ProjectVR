using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// 2月~16日　瀧本　基礎（ScoreUｐ、AnimEnd）
// 2016/02/17 梅村 Score.csの修正したので、ScorePlus()の修正

public class ScoreUpAnim : MonoBehaviour {

	[SerializeField]
	PlayerData PlayerData;
	[SerializeField]
	Animator subScoreAnimation;
	Text scoreUpAnimText;
	[SerializeField]
	Score score;
	int upScore;
	//追加scoreの変動するための変数
	int killLevel;

	void Awake(){
		scoreUpAnimText = gameObject.GetComponent<Text>();
		subScoreAnimation.enabled = false;
		scoreUpAnimText.enabled = false;
		killLevel = 0;
	}
	//加算点数の追加
	//呼べば動く
	public void ScoreUp(){
		killLevel = PlayerData.killCombo / 50;
		scoreUpAnimText.enabled = true;
		subScoreAnimation.enabled = true;
		subScoreAnimation.SetBool("subScore", true );
		upScore = 5000 * killLevel * killLevel * killLevel;
		scoreUpAnimText.text = "+"+upScore +"点"; 
	}
	
	//アニメーション終わったら勝手に呼ばれる
	public void AnimEnd(){
		subScoreAnimation.SetBool("subScore", false );
		subScoreAnimation.enabled = false;
		scoreUpAnimText.enabled = false;
		score.ScorePlus (upScore);
	}
}

