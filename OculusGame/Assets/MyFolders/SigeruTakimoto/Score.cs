using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// 2月~16日　瀧本　全部

public class Score : MonoBehaviour {
	[SerializeField]
	Text scoreText;
	[SerializeField]
	PlayerData playerData;
void Awake(){
		scoreText.text = playerData.score+"点";
	}
	public	void ScoreDraw(){
		scoreText.text = playerData.score+"点";
	}
}
