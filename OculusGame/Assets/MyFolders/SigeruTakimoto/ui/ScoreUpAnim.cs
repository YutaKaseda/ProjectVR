using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// 2月~16日　瀧本　基礎（ScoreUｐ、AnimEnd）
// 2016/02/17 梅村 Score.csの修正したので、ScorePlus()の修正
// 2016/02/19 梅村 全体的に見やすくなったかな？
public class ScoreUpAnim : MonoBehaviour {

	Score score;
	Text scoreUpAnimText2D;
	Text scoreUpAnimText3D;
	[SerializeField]
	Animator subScoreAnimation;
	int bonusScore;//コンボボーナス

	void Awake(){
		score = gameObject.GetComponent<Score>();
		scoreUpAnimText2D = GameObject.Find("ScoreUpAnim2D").GetComponent<Text>();
		scoreUpAnimText3D = GameObject.Find("ScoreUpAnim3D").GetComponent<Text>();
		ScoreUpAnimTextInit ();

	}
	//加算点数の追加
	//呼べば動く
	public void ScoreUp(int bonusLevel){
		bonusScore = 1000 * bonusLevel;
		subScoreAnimation.SetBool("subScore", true );
		scoreUpAnimText2D.text = "+"+bonusScore +"点"; 
		scoreUpAnimText3D.text = "+"+bonusScore +"点"; 
	}
	
	//アニメーション終わったら勝手に呼ばれる
	public void AnimEnd(){
		ScoreUpAnimTextInit ();
		subScoreAnimation.SetBool("subScore", false );
		score.ScorePlus (bonusScore);
	}

	public void ScoreUpAnimTextInit(){
		scoreUpAnimText2D.text = ""; 
		scoreUpAnimText3D.text = ""; 
	}
}

