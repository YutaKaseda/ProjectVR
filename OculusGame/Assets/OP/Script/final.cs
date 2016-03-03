using UnityEngine;
using System.Collections;

public class final : MonoBehaviour 
{
	AudioSource audioSource;		//音再生用
	public AudioClip audioClip1;	//Vo.「準備はいいですか？」
	public AudioClip audioClip2;	//Vo.「10,9,8,7,6,5,4,3,2,1,0」
	public AudioClip audioClip3;	//Vo.「がんばれー」
	public AudioClip audioClip4;	//SE.超ワープ音

    [SerializeField]
	private RectTransform fade;

    [SerializeField]
	GameObject effectObject;
    [SerializeField]
	GameObject fadeObject;

	public int check = 0;
	int flg = 0;
	float timeleft = 20f;
	float x = 0;
	float y = 0;


	void Awake () 
	{
		fade = GameObject.Find ("Image").GetComponent<RectTransform> ();
		fade.sizeDelta = new Vector2(0,0);

		audioSource = gameObject.GetComponent<AudioSource>();	//音情報を習得
		audioSource.clip = audioClip1;
		audioSource.clip = audioClip2;
		audioSource.clip = audioClip3;
		audioSource.clip = audioClip4;

		audioSource.PlayOneShot( audioClip1 );

		effectObject = GameObject.Find("Warp Effect");
		fadeObject = GameObject.Find("FadeCanvas");
		fadeObject.SetActive(false);
		effectObject.SetActive(false);
	}
	
	void Update () 
	{
		CountDown ();
		FadeIn ();
	}

	void CountDown()
	{
		timeleft -= Time.deltaTime; 
		if (timeleft <= 18f) 
		{
			if (flg == 0) 
			{
				audioSource.PlayOneShot (audioClip2);
				effectObject.SetActive(true);
				flg = 1;

			}
		} 
		if (timeleft <= 5f) 
		{
			if (flg == 1)
			{
				audioSource.PlayOneShot (audioClip3);
				flg = 2;
			}
		}
	}

	void FadeIn()
	{
		if (check == 1) 
		{
			fadeObject.SetActive(true);
			StartCoroutine ("Fade");
		}
		if (check == 2) 
		{
			audioSource.PlayOneShot( audioClip4,0.5f );
			check = 3;
		}
	}

	private IEnumerator Fade()
	{
		for (int i=0; i<=5; i++) 
		{
			yield return new WaitForSeconds (0.01f);
			x +=100f;
			y +=160f;

			fade.sizeDelta = new Vector2(x,y);
		}
		check =2;
	}
}
