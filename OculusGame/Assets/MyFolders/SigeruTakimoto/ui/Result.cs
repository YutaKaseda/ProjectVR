/// <summary>
/// Result.
/// 16/3/6 梅村 作成
/// </summary>
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Result : MonoBehaviour {

	[SerializeField]
	Text scoreText,comboText,lifeText,totalText;


    [SerializeField]
    Text rank,topKiller,highScore;

	float plusNo;
	int totalScore;

	void Awake(){
		plusNo = 0;
		StartCoroutine(ResultAnim (PlayerPrefs.GetInt("NowScore"), PlayerPrefs.GetInt("Now2DLife"), PlayerPrefs.GetInt("NowTopKill")));
	}

	public IEnumerator ResultAnim(int score,int life,int combo){
		totalScore = score + (life * 10000) + (combo * 100);

        yield return new WaitForSeconds(1.0f);

        SoundPlayer.Instance.PlaySoundEffect("mate", 1.0f);

        yield return new WaitForSeconds(2.0f);
        SoundPlayer.Instance.PlaySoundEffect("Click", 1.0f);
		while(combo > plusNo){
			plusNo += combo * Time.deltaTime;
			comboText.text = "" + (int)plusNo;
			yield return null;
		}
        SoundPlayer.Instance.PlaySoundEffect("Enter", 1.0f);
		comboText.text = "" + combo;//合わせる
		plusNo = 0;
		yield return new WaitForSeconds (0.5f);
        SoundPlayer.Instance.PlaySoundEffect("Click", 1.0f);


		while(life > plusNo){
			plusNo += life * Time.deltaTime;
			lifeText.text = "" + (int)plusNo;
			yield return null;
		}
        SoundPlayer.Instance.PlaySoundEffect("Enter", 1.0f);
		lifeText.text = "" + life;//合わせる
		plusNo = 0;
		yield return new WaitForSeconds (0.5f);
        SoundPlayer.Instance.PlaySoundEffect("Click", 1.0f);

		while(score > plusNo){
			plusNo += score * Time.deltaTime;
			scoreText.text = "" + (int)plusNo;
			yield return null;
		}
        SoundPlayer.Instance.PlaySoundEffect("Enter", 1.0f);
		scoreText.text = "" + score;//合わせる
		plusNo = 0;
		yield return new WaitForSeconds (0.5f);
        SoundPlayer.Instance.PlaySoundEffect("Click", 1.0f);

		while(totalScore > plusNo){
			plusNo += totalScore * Time.deltaTime;
			totalText.text = "" + (int)plusNo;
			yield return null;
		}
		totalText.text = "" + totalScore;//合わせる
		plusNo = 0;
		yield return new WaitForSeconds (1f);

        SoundPlayer.Instance.PlaySoundEffect("Enter", 1.0f);


		//rank分岐
		if(totalScore < 10000000){//C
            rank.text = "C";
		}
		else if(totalScore >= 10000000 && totalScore < 20000000){//B
            rank.text = "B";
		}
		else if(totalScore >= 20000000 && totalScore < 30000000){//A
            rank.text = "A";
		}
		else if(totalScore >= 30000000 && totalScore < 50000000){//S
            rank.text = "S";
		}
		else if(totalScore >= 50000000){//SS
            rank.text = "SS";
		}

		rank.enabled = true;
        SoundPlayer.Instance.PlaySoundEffect("menu2", 1.0f);
        SoundPlayer.Instance.PlaySoundEffect("omedetou", 1.0f);

        if (combo > PlayerPrefs.GetInt("TopKill"))
        {
            yield return new WaitForSeconds(2.0f);
            topKiller.enabled = true;
            PlayerPrefs.SetInt("TopKill", combo);
            SoundPlayer.Instance.PlaySoundEffect("excellent", 1.0f);
            SoundPlayer.Instance.PlaySoundEffect("menu2", 1.0f);
        }

        if (totalScore > PlayerPrefs.GetInt("HighScore"))
        {
            yield return new WaitForSeconds(2.0f);
            highScore.enabled = true;
            PlayerPrefs.SetInt("HighScore", totalScore);
            SoundPlayer.Instance.PlaySoundEffect("mave", 1.0f);
            SoundPlayer.Instance.PlaySoundEffect("menu2", 1.0f);
        }

        yield return new WaitForSeconds(2.0f);

        SoundPlayer.Instance.PlaySoundEffect("mataasobe", 1.0f);


		while(true){
			if(Input.GetKeyDown(KeyCode.Return)){
				Application.LoadLevelAsync("network_offline"); 
				break;
			}
			yield return null;
		}
	}
}
