using UnityEngine;
using System.Collections;

public class Effect : MonoBehaviour 
{
	AudioSource audioSource;		//音再生用
	public AudioClip audioClip1;	//SE.シュン

	GameObject effectObject;

	int count =0;
	float timeleft;

	void Awake () 
	{
		audioSource = gameObject.GetComponent<AudioSource>();	//音情報を習得
		audioSource.clip = audioClip1;
		effectObject = GameObject.Find ("Music");
	}
	
	void Update () 
	{
		Se_play ();
		Object_size ();
	}


	void Se_play()
	{
		timeleft -= Time.deltaTime; 
		if (count >= 12) 
		{
			count =13;
		}
		else
		{
			if (timeleft <= 0) 
			{
				timeleft = 1.0f;
				audioSource.PlayOneShot (audioClip1);
				count += 1;
			}
		}
	}
	void Object_size()
	{
		switch (count) 
		{
		case 1:
			transform.localScale = new Vector3 (1, 10, 1);
			break;
		case 2:
			transform.localScale = new Vector3 (1, 20, 1);
			break;
		case 3:
			transform.localScale = new Vector3 (1, 30, 1);
			break;
		case 4:
			transform.localScale = new Vector3 (1, 40, 1);
			break;
		case 5:
			transform.localScale = new Vector3 (1, 50, 1);
			break;
		case 6:
			transform.localScale = new Vector3 (1, 60, 1);
			break;
		case 7:
			transform.localScale = new Vector3 (1, 70, 1);
			break;
		case 8:
			transform.localScale = new Vector3 (1, 80, 1);
			break;
		case 9:
			transform.localScale = new Vector3 (1, 90, 1);
			break;
		case 10:
			transform.localScale = new Vector3 (1, 100, 1);
			break;
		case 11:
			transform.localScale = new Vector3 (1, 110, 1);
			break;
		case 12:
			effectObject.GetComponent<final>().check = 1;
			break;
		case 13:
			GameObject.Destroy(gameObject);
			break;
		}
	}
}
