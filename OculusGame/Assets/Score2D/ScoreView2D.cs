using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreView2D : MonoBehaviour {

    private Text scoreText;
    private float score;
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
        Debug.Log("ScoreUpdate");
    }
}
