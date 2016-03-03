/**********************************************************************
*** 2016/3/1(Tue)志村健太 メーターの様なUIを表示するスクリプト (音も出ます) *
**********************************************************************/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class meterUI : MonoBehaviour 
{
	float timeleft =0;		 	//時間習得用
	Image image;			 	//画像情報格納用
	int flg   =0;
	int okflg =0;
	public Text meterText; 	 	//テキスト格納用
	private float meter = 0; 	//テキスト表示用 

	public AudioClip audioClip1;	//Vo.「起動します」
	public AudioClip audioClip2;	//Vo.「データを読み込んでいます」
	public AudioClip audioClip3;	//SE.秒音
	public AudioClip audioClip4;	//SE.起動音
	AudioSource audioSource;		//音再生用


	void Awake () 
	{
		audioSource = gameObject.GetComponent<AudioSource>();	//音情報を習得
		audioSource.clip = audioClip1;
		audioSource.clip = audioClip2;
		audioSource.clip = audioClip3;
		image = GetComponent<Image>();							//画像情報を習得
		meterText.text = "0"; 									//初期値を代入して画面に表示
		audioSource.PlayOneShot( audioClip2 );
	}
	
	void Update () 
	{
		Meter();
		SEPlay ();
	}





	void Meter()
	/************************************************************
	** タコメーターの様な画像を非表示状態から円を描く様に徐々に表示し   *
	** それに合わせて数字で表示率も動的に表示する関数                 *
	*************************************************************/
	{
	//画像は1がMAX
	//数字は100がMAXとした
		if (meter == 100) 
		//描画完了
		{ 
			meter = 100;
			image.fillAmount = 1;
			meterText.text = "" + meter.ToString ();
			flg = 1;
		} 
		else if (meter >= 62 && meter <= 70) 
		//1秒に1づず描画する
		{ 
			timeleft -= Time.deltaTime; 
			if (timeleft <= 0.0) 
			{
				timeleft = 1.0f;
				meter += 1;
				image.fillAmount += 0.01f;
				audioSource.PlayOneShot( audioClip3 );
				meterText.text = "" + meter.ToString ();
			}
		} 
		else
		//frame依存で描画
		{
			meter += 1f;
			image.fillAmount += 0.01f;
			audioSource.PlayOneShot( audioClip3 );
			meterText.text = "" + meter.ToString();
		}
	}


	void SEPlay()
	/********************************************
	** 特定のタイミングと回数でSEを再生する為の関数 **
	********************************************/
	{
		if (flg == 1) 
		{
			audioSource.PlayOneShot( audioClip4 );
			if(okflg == 0)
			{
				audioSource.PlayOneShot( audioClip1 );
				audioSource.PlayOneShot( audioClip4 );
				flg = 0;
				okflg = 1;
			}
		}
	}
}
