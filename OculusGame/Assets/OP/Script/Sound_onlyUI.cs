/********************************************************************************
*** 2016/3/2(Wed)志村健太 SOUND ONLYと書かれた画像を表示しそれに合わせたボイスも出ます *
********************************************************************************/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Sound_onlyUI : MonoBehaviour 
{
    [SerializeField]
	private RectTransform sonly;
    [SerializeField]
	private RectTransform cir;

    [SerializeField]
	private RectTransform ocu;
    [SerializeField]
	private RectTransform boss;
    [SerializeField]
	private RectTransform zako;
    [SerializeField]
    private RectTransform attack;
    [SerializeField]
    private RectTransform warp;

    [SerializeField]
	GameObject warpObject;

	public Text warpText; 	 	//テキスト格納用
    
    [SerializeField]
	Image warp_in;

	float image_size_x1=0;
	float image_size_x2=0;
	float image_size_y1=0;
	float image_size_y2=0;

	float image_x1 =0;
	float image_x2 =0;
	float image_x3 =0;
	float image_x4 =0;
	float image_x5 =0;

	float image_y1 =0;
	float image_y2 =0;
	float image_y3 =0;
	float image_y4 =0;
	float image_y5 =0;

	float timeleft;
	float timeleft2 = 80;

	int voiceflg =0;
	int fadeflg  =1;

	AudioSource audioSource;		//音再生用
	public AudioClip audioClip1;	//SE.ぱち
	public AudioClip audioClip2;	//Vo.内藤ナビ

	int count = 0;

	void Awake () 
	{
		//sonly = GameObject.Find ("sound only").GetComponent<RectTransform> ();
		//cir   = GameObject.Find ("circle").GetComponent<RectTransform> ();

		sonly.sizeDelta = new Vector2(image_size_x1,image_size_y1);
		cir.sizeDelta = new Vector2(image_size_x2,image_size_y2);

		//ocu   = GameObject.Find ("Image Ocu").GetComponent<RectTransform> ();
		//boss   = GameObject.Find ("Image Boss").GetComponent<RectTransform> ();
		//zako   = GameObject.Find ("Image Zako").GetComponent<RectTransform> ();
		//attack   = GameObject.Find ("Image Attack").GetComponent<RectTransform> ();
		//warp   = GameObject.Find ("Image Warp").GetComponent<RectTransform> ();

		ocu.sizeDelta = new Vector2 (image_x1, image_y1);
		boss.sizeDelta = new Vector2 (image_x2, image_y2);
		zako.sizeDelta = new Vector2 (image_x3, image_y3);
		attack.sizeDelta = new Vector2 (image_x4, image_y4);
		warp.sizeDelta = new Vector2 (image_x5, image_y5);

		audioSource = gameObject.GetComponent<AudioSource>();	//音情報を習得
		audioSource.clip = audioClip1;
		audioSource.PlayOneShot( audioClip1 );
		StartCoroutine ("Sound_Only");

		warpObject.SetActive(false);
	}
	

	void Update () 
	{
		Warp_system ();
		timeleft2 -= Time.deltaTime; 
		if (timeleft2 <= 79f && timeleft2 >= 78f) 
		{
			Navi_voice();
		}
		if(timeleft2 <= 73f && timeleft2 >= 72f)
		{
			fadeflg = 1;
			StartCoroutine ("Oculus");
			//Pachi ();
		}
		if (timeleft2 <= 68f && timeleft2 >= 67f) 
		{
			fadeflg = 2;
			StartCoroutine ("Oculus");
			//Pachi ();
		}
		if (timeleft2 <= 65f && timeleft2 >= 64f) 
		{
			fadeflg = 1;
			StartCoroutine ("Boss");
			StartCoroutine ("Zako");
			//Pachi ();
		}
		if (timeleft2 <= 51f && timeleft2 >= 50f) 
		{
			fadeflg = 2;
			StartCoroutine ("Boss");
			StartCoroutine ("Zako");
			//Pachi ();
		}
		if (timeleft2 <= 42f && timeleft2 >= 41f) 
		{
			fadeflg = 1;
			StartCoroutine ("Warp");
			//Pachi ();
		}
		if (timeleft2 <= 36f && timeleft2 >= 35f) 
		{
			fadeflg = 2;
			StartCoroutine ("Warp");
			//Pachi ();
		}
		if (timeleft2 <= 31f && timeleft2 >= 30f) 
		{
			fadeflg = 1;
			StartCoroutine ("Attack");
			//Pachi ();
		}
		if (timeleft2 <= 25f && timeleft2 >= 24f) 
		{
			fadeflg = 2;
			StartCoroutine ("Attack");
			//Pachi ();
		}
		if (timeleft2 <= 0f && timeleft2 >= -1f) 
		{
			fadeflg = 2;
			StartCoroutine ("Sound_Only");
			Pachi ();

		}
		if (timeleft2 <= -30f) 
		{
			GameObject.Destroy(gameObject);
		}
	}

	private IEnumerator Sound_Only()
	/****************************************
	*** SOUND ONLY UI　を拡大する様に表示する **
	****************************************/
	{
		if (fadeflg == 1) 
		{
			for (int i=0; i<=10; i++) 
			{
				yield return new WaitForSeconds (0.01f);
				image_size_x1 += 60;
				image_size_x2 += 43;
				image_size_y1 += 62;
				image_size_y2 += 43;
				sonly.sizeDelta = new Vector2 (image_size_x1, image_size_y1);
				cir.sizeDelta = new Vector2 (image_size_x2, image_size_y2);
			}
			sonly.sizeDelta = new Vector2 (660, 696);
			cir.sizeDelta = new Vector2 (482, 482);
		}
		if (fadeflg == 2) 
		{
			for (int i=0; i<=10; i++) 
			{
				yield return new WaitForSeconds (0.01f);
				image_size_x1 -= 60;
				image_size_x2 -= 43;
				image_size_y1 -= 62;
				image_size_y2 -= 43;
				sonly.sizeDelta = new Vector2 (image_size_x1, image_size_y1);
				cir.sizeDelta = new Vector2 (image_size_x2, image_size_y2);
			}
			sonly.sizeDelta = new Vector2 (0, 0);
			cir.sizeDelta = new Vector2 (0, 0);
		}
	}

	private IEnumerator Oculus()
	//Oculus Rift画像表示
	{
		if (fadeflg == 1) 
		{
			for (int a=0; a<=9; a++) 
			{
				yield return new WaitForSeconds (0.01f);
				image_x1 +=10;
				image_y1 += 10;
				ocu.sizeDelta = new Vector2 (image_x1, image_y1);
			}
			ocu.sizeDelta = new Vector2 (image_x1=610, image_y1=631);
		} 
		else if (fadeflg == 2) 
		{
			for (int a=0; a<=9; a++) 
			{
				yield return new WaitForSeconds (0.01f);
				image_x1 -= 10;
				image_y1 -= 10;
				ocu.sizeDelta = new Vector2 (image_x1, image_y1);
			}
			ocu.sizeDelta = new Vector2 (image_x1=0, image_y1=0);
		}
	}

	private IEnumerator Boss()
	//Boss画像表示
	{
		if (fadeflg == 1) 
		{
			for (int a=0; a<=9; a++) 
			{
				yield return new WaitForSeconds (0.01f);
				image_x2 +=10;
				image_y2 += 10;
				boss.sizeDelta = new Vector2 (image_x2, image_y2);
			}
			boss.sizeDelta = new Vector2 (image_x2=610, image_y2=631);
		} 
		else if (fadeflg == 2) 
		{
			for (int a=0; a<=9; a++) 
			{
				yield return new WaitForSeconds (0.01f);
				image_x2 -= 10;
				image_y2 -= 10;
				boss.sizeDelta = new Vector2 (image_x2, image_y2);
			}
			boss.sizeDelta = new Vector2 (image_x2=0, image_y2=0);
		}
	}

	private IEnumerator Zako()
		//ざこ画像表示
	{
		if (fadeflg == 1) 
		{
			for (int a=0; a<=9; a++) 
			{
				yield return new WaitForSeconds (0.01f);
				image_x3 +=10;
				image_y3 += 10;
				zako.sizeDelta = new Vector2 (image_x3, image_y3);
			}
			zako.sizeDelta = new Vector2 (image_x3=610, image_y3=631);
		} 
		else if (fadeflg == 2) 
		{
			for (int a=0; a<=9; a++) 
			{
				yield return new WaitForSeconds (0.01f);
				image_x3 -= 10;
				image_y3 -= 10;
				zako.sizeDelta = new Vector2 (image_x3, image_y3);
			}
			zako.sizeDelta = new Vector2 (image_x3=0, image_y3=0);
		}
	}

	private IEnumerator Warp()
	//ワープ画像表示
	{
		if (fadeflg == 1) 
		{
			for (int a=0; a<=9; a++) 
			{
				yield return new WaitForSeconds (0.01f);
				image_x5 +=10;
				image_y5 += 10;
				warp.sizeDelta = new Vector2 (image_x5, image_y5);
			}
			warp.sizeDelta = new Vector2 (image_x5=610, image_y5=631);
		} 
		else if (fadeflg == 2) 
		{
			for (int a=0; a<=9; a++) 
			{
				yield return new WaitForSeconds (0.01f);
				image_x5 -= 10;
				image_y5 -= 10;
				warp.sizeDelta = new Vector2 (image_x5, image_y5);
			}
			warp.sizeDelta = new Vector2 (image_x5=0, image_y5=0);
		}
	}

	private IEnumerator Attack()
		//ワープ画像表示
	{
		if (fadeflg == 1) 
		{
			for (int a=0; a<=9; a++) 
			{
				yield return new WaitForSeconds (0.01f);
				image_x4 +=10;
				image_y4 += 10;
				attack.sizeDelta = new Vector2 (image_x4, image_y4);
			}
			attack.sizeDelta = new Vector2 (image_x4=610, image_y4=631);
		} 
		else if (fadeflg == 2) 
		{
			for (int a=0; a<=9; a++) 
			{
				yield return new WaitForSeconds (0.01f);
				image_x4 -= 10;
				image_y4 -= 10;
				attack.sizeDelta = new Vector2 (image_x4, image_y4);
			}
			attack.sizeDelta = new Vector2 (image_x4=0, image_y4=0);
		}
	}


	void Warp_system()
	/************************************
	*** ワープシステムのバーを管理する関数 **
	************************************/
	{
		warpObject.SetActive(true);
		if (count >= 99) 
		{
			warp_in.fillAmount = 1;
			warpText.text = "ワープシステム起動完了" + ToString ();
		}
		else 
		{
			timeleft -= Time.deltaTime; 
			if (timeleft <= 0.0) 
			{
				timeleft = 1.0f;
				warp_in.fillAmount += 0.01f;
				count += 1;
			}
		}
	}

	void Navi_voice()
	{
		if (voiceflg == 0) 
		{
			audioSource.PlayOneShot (audioClip2,1.0f);
			voiceflg = 1;
		}
	}
	void Pachi()
	{
		timeleft -= Time.deltaTime; 
		if (timeleft <= 0.0) 
		{
            audioSource.PlayOneShot(audioClip1, 1.0f);
			timeleft = 1.0f;
		}
	}
}
