using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// 2月~16日　瀧本　Scoredraw
// 2016/02/17 梅村 ScorePlusの汎用性をあげた
public class Score : MonoBehaviour {
	Text scoreText2D;
	Text scoreText3D;
	[SerializeField]
	PlayerData playerData;

	void Awake(){
		scoreText2D = GameObject.Find("Score2D").GetComponent<Text>();
		scoreText3D = GameObject.Find("Score3D").GetComponent<Text>();
		scoreText2D.text = playerData.score+"点";
		scoreText3D.text = playerData.score+"点";
	}

	public void ScorePlus(double upScore){

		playerData.score += upScore;
		scoreText2D.text = playerData.score+"点";
		scoreText3D.text = playerData.score+"点";
	}
}
