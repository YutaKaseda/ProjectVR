using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// 2月~16日　瀧本　Scoredraw
// 2016/02/17 梅村 ScorePlusの汎用性をあげた
public class Score : MonoBehaviour {
	Text scoreText;
	[SerializeField]
	PlayerData playerData;

	void Awake(){
		scoreText = gameObject.GetComponent<Text>();
		scoreText.text = playerData.score+"点";
	}

	public void ScorePlus(double upScore){

		playerData.score += upScore;
		scoreText.text = playerData.score+"点";
	}
}
