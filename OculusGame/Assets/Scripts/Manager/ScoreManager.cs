using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public int score { get; private set; }
    int scoreYard;
    GameObject scoreView2D;
	GameObject scoreView3D;
	// Use this for initialization
	void Awake () {
        score = 0;
        scoreYard = 0;
        scoreView2D = GameObject.Find("ScorePoint2D");
		scoreView3D = GameObject.Find("ScorePoint3D");
	}

    public void plusScore(int plus){

        scoreYard += plus;
        StartCoroutine(Coroutine());
        
    }

    IEnumerator Coroutine()
    {
        while (scoreYard > 0)
        {
            score += 100;
            scoreYard -= 100;
            //scoreView2D.GetComponent<ScoreView2D>().DrawScore();
			scoreView3D.GetComponent<ScoreView3D>().DrawScore();
            yield return null;
        }
    }
}
