/**********************************************************
*** 2016/3/1(Tue)志村健太 UIのプレハブを時間で管理するスクリプト *
**********************************************************/
//3/3悴田の魔改造

using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour 
{
	float time =0;	//時間用
	int flg =0;

    [SerializeField]
	GameObject ui1;     //プレハブに情報を格納する	
    [SerializeField]
    GameObject ui2;
    [SerializeField]
	GameObject ui3;
    [SerializeField]
	GameObject ui4;

    [SerializeField]
    GameObject oui1;     //プレハブに情報を格納する	
    [SerializeField]
    GameObject oui2;
    [SerializeField]
    GameObject oui3;
    [SerializeField]
    GameObject oui4;

	void Awake()
	{
        ui1.SetActive(true);
        oui1.SetActive(true);
	}

	void Update () 
	{
		Story ();
	}

	void Story()
	/*******************************************
	*** 時間でプレハブを生成破棄をし物語は進む... ***
	********************************************/
	{
		time += Time.deltaTime;
		if (time >= 13) 
		{
			GameObject.Destroy (ui1);
            GameObject.Destroy(oui1);
		}
		if (time >= 14) 
		{
			Ui2 ();
		}
		if (time >= 24) 
		{
			GameObject.Destroy (ui2);
            GameObject.Destroy(oui2);
		}
		if (time >= 25) 
		{
			Ui3 ();
		}
		if (time >= 129) 
		{
			GameObject.Destroy (ui3);
            GameObject.Destroy(oui3);
		}
		if (time >= 130) 
		{
			Ui4();
		}
		if(time >= 155)
		{
			GameObject.Destroy (ui4);
            GameObject.Destroy(oui4);
            Application.LoadLevel("OnlineLevel");
		}
	}

	void Ui2()
	{
		if (flg == 0) 
		{
            ui2.SetActive(true);
            oui2.SetActive(true);
			flg = 1;
		}
	}
	void Ui3()
	{
		if (flg == 1) 
		{
            ui3.SetActive(true);
            oui3.SetActive(true);
            flg = 2;
		}
	}
	void Ui4()
	{
		if (flg == 2) 
		{
            ui4.SetActive(true);
            oui4.SetActive(true);
            flg = 3;
		}
	}

}
