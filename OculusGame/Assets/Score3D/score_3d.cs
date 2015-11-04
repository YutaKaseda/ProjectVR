using UnityEngine;
using System.Collections;
using UnityEngine.UI;	//UI用

public class score_3d : MonoBehaviour 
{
	public int score { get; private set; }
	int scoreYard;
	GameObject scoreView3D;
	
	// Use this for initialization
	void Awake () 
	{
		      score = 0;
		  scoreYard = 0;
		scoreView3D = GameObject.Find("ScorePoint");
	}
	
	public void plusScore(int plus)
	{	
		scoreYard += plus;
		StartCoroutine(Coroutine());	
	}
	
	IEnumerator Coroutine()
	{
		while (scoreYard > 0)
		{
			score += 100;
			scoreYard -= 100;
			scoreView3D.GetComponent<ScoreView2D>().DrawScore();
			yield return null;
		}
	}
}
