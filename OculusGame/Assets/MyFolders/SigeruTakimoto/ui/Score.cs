using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// 2月~16日　瀧本　Scoredraw
// 2016/02/17 梅村 ScorePlusの汎用性をあげた
// 2016/02/19 梅村 全体的に見やすくなったかな？
public class Score : MonoBehaviour {

	PlayerData playerData;
	Text scoreText2D;
	Text scoreText3D;

	void Awake(){
		playerData = GameObject.FindWithTag("Player2D").GetComponent<PlayerData>();
		scoreText2D = GameObject.Find("Score2D").GetComponent<Text>();
		scoreText3D = GameObject.Find("Score3D").GetComponent<Text>();
		ScoreDraw ();
	}

	public void ScorePlus(double upScore){
		playerData.score += upScore;
		ScoreDraw ();
	}

	public void ScoreDraw(){
		scoreText2D.text = playerData.score+"点";
		scoreText3D.text = playerData.score+"点";
	}
}
