/*****************************************************************
*** 2016/3/1(Tue)志村健太 ようこそなUIを表示するスクリプト(音も出ます) *
*****************************************************************/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class welcomUI : MonoBehaviour 
{
	Image image1;
	Image image2;
	GameObject textObject;

	float cunt1 =0;
	float cunt2 =1;
	float timeleft = 5.0f;
	int flg = 0;
	int se_play= 0;

	AudioSource audioSource;		//音再生用
	public AudioClip audioClip1;	//SE.シュン
	public AudioClip audioClip2;	//Vo.「ようこそ」

	void Awake () 
	{
		image1     = GameObject.Find ("UI1").GetComponent<Image>();	//画像情報を習得
		image2     = GameObject.Find ("UI2").GetComponent<Image>();	//画像情報を習得
		textObject = GameObject.Find("Text_welcom");
		textObject.SetActive(false);

		audioSource = gameObject.GetComponent<AudioSource>();	//音情報を習得
		audioSource.clip = audioClip1;
		audioSource.clip = audioClip2;

		audioSource.PlayOneShot( audioClip1 );
	}
	

	void Update () 
	{
		Indication();
	}

	void Indication()
	/*****************************************************************
	*** あみあみな青い画像を左から徐々に表示し、再度左から徐々に非常時にし ***
	*** Textを表示し、それに合わせたタイミングでSEを再生する関数         ***
	*****************************************************************/
	{
		if (flg == 0) 
		//左から徐々に表示
		{
			if (cunt1 >= 1) 
			{
				cunt1 = 1;
				flg = 1;
			}
			else 
			{
				cunt1 += 0.05f;
				image1.fillAmount = cunt1;
			}
		}
		else if (flg == 1)
		//画像を表示した状態でテキストを表示
		{
			Vo_play();
			textObject.SetActive(true);
			timeleft -= Time.deltaTime;
			if (timeleft <= 0.0)
			{
				GameObject.Destroy (image1);
				flg = 2;
			}
		}
		else if (flg == 2) 
		//テキストを非表示にし画像を左から徐々に非表示
		{
			Se_play ();
			textObject.SetActive(false);
			if(cunt2 <= 0)
			{
				cunt2 = 0;
			}
			else
			{
				cunt2 -= 0.05f;
				image2.fillAmount = cunt2;
			}
		}
	}



	void Vo_play()
	//一回だけUpdate関数内で鳴らしたい為の処理を書いた関数
	{
		if (se_play == 0) 
		{
			audioSource.PlayOneShot (audioClip2);
			se_play = 1;
		}
	}

	void Se_play()
	//上記関数と同じ
	{
		if (se_play == 1) 
		{
			audioSource.PlayOneShot (audioClip1);
			se_play = 2;
		}
	}
}