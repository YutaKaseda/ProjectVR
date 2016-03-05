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
	Image rankImage;

	[SerializeField]
	Sprite rankSS,rankS,rankA,rankB,rankC;

	float plusNo;
	int totalScore;

	void Awake(){
		plusNo = 0;
		rankImage.enabled = false;
		StartCoroutine(ResultAnim (10000000, 99, 500));
	}

	public IEnumerator ResultAnim(int score,int life,int combo){
		totalScore = score + (life * 100) + (combo * 100);


		while(combo > plusNo){
			plusNo += combo * Time.deltaTime;
			comboText.text = "" + (int)plusNo;
			yield return null;
		}
		comboText.text = "" + combo;//合わせる
		plusNo = 0;
		yield return new WaitForSeconds (0.5f);


		while(life > plusNo){
			plusNo += life * Time.deltaTime;
			lifeText.text = "" + (int)plusNo;
			yield return null;
		}
		lifeText.text = "" + life;//合わせる
		plusNo = 0;
		yield return new WaitForSeconds (0.5f);


		while(score > plusNo){
			plusNo += score * Time.deltaTime;
			scoreText.text = "" + (int)plusNo;
			yield return null;
		}
		scoreText.text = "" + score;//合わせる
		plusNo = 0;
		yield return new WaitForSeconds (0.5f);


		while(totalScore > plusNo){
			plusNo += totalScore * Time.deltaTime;
			totalText.text = "" + (int)plusNo;
			yield return null;
		}
		totalText.text = "" + totalScore;//合わせる
		plusNo = 0;
		yield return new WaitForSeconds (1f);


		//rank分岐
		if(totalScore < 500000){//C
			rankImage.sprite = rankC;
		}
		else if(totalScore >= 500000 && totalScore < 2000000){//B
			rankImage.sprite = rankB;
		}
		else if(totalScore >= 2000000 && totalScore < 7000000){//A
			rankImage.sprite = rankA;
		}
		else if(totalScore >= 7000000 && totalScore < 10000000){//S
			rankImage.sprite = rankS;
		}
		else if(totalScore >= 10000000){//SS
			rankImage.sprite = rankSS;
		}

		rankImage.enabled = true;

		while(true){
			if(Input.GetKeyDown(KeyCode.Space)){
				Application.LoadLevelAsync("network_offline"); 
				break;
			}
			yield return null;
		}
	}
}
