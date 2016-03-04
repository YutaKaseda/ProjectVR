using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OfflineAvoid : MonoBehaviour {

    [SerializeField]
    Text topKill;
    [SerializeField]
    Text highScore;

    void Awake(){
        if (PlayerPrefs.HasKey("HighScore"))
            highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
        else
            PlayerPrefs.SetInt("HighScore", 0);

        if (PlayerPrefs.HasKey("TopKill"))
            topKill.text = PlayerPrefs.GetInt("TopKill").ToString();
        else
            PlayerPrefs.SetInt("TopKill", 0);
    }

    void Update(){

        if(Input.GetButtonDown("MaruP1") || Input.GetButtonDown("BatuP1") ||
            Input.GetButtonDown("ShikakuP1") || Input.GetButtonDown("SankakuP1"))
        {
            Application.LoadLevelAsync("VROP");
        }

    }
	
}
