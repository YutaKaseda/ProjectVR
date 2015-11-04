using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreView3D : MonoBehaviour {
	
	Text scoreText;
	int score;
	GameObject dataManager;
	
	public void Awake()
	{
		scoreText = GetComponent<Text>();
		dataManager = GameObject.Find("DataManager");
	}
	
	public void DrawScore()
	{
		score = dataManager.GetComponent<ScoreManager>().score;
		scoreText.text = score.ToString();
	}
}
