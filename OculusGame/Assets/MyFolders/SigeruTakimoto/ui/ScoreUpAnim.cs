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
	Text scoreUpAnimText2D;
	Text scoreUpAnimText3D;
	Score score;
	int upScore;
	//追加scoreの変動するための変数
	int killLevel;

	void Awake(){
		score = gameObject.GetComponent<Score>();
		scoreUpAnimText2D = GameObject.Find("ScoreUpAnim2D").GetComponent<Text>();
		scoreUpAnimText3D = GameObject.Find("ScoreUpAnim3D").GetComponent<Text>();
		subScoreAnimation.enabled = false;
		scoreUpAnimText2D.enabled = false;
		scoreUpAnimText3D.enabled = false;
		killLevel = 0;
	}
	//加算点数の追加
	//呼べば動く
	public void ScoreUp(){
		killLevel = PlayerData.killCombo / 50;
		subScoreAnimation.enabled = true;
		subScoreAnimation.SetBool("subScore", true );
		upScore = 5000 * killLevel * killLevel * killLevel;
		scoreUpAnimText2D.text = "+"+upScore +"点"; 
		scoreUpAnimText3D.text = "+"+upScore +"点"; 
	}
	
	//アニメーション終わったら勝手に呼ばれる
	public void AnimEnd(){
		subScoreAnimation.SetBool("subScore", false );
		subScoreAnimation.enabled = false;
		scoreUpAnimText2D.enabled = false;
		scoreUpAnimText3D.enabled = false;
		score.ScorePlus (upScore);
	}
}

