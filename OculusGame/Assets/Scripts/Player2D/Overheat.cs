using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Overeat: MonoBehaviour {

	[SerializeField]
	PlayerData2D playerData;

	//シェーダー設定
	[SerializeField]
	Slider bomSlider;
	[SerializeField]
	Slider cannonSlider;
	
	public struct CoolTimeFlg
	{
		public bool cannon{ get; set; }
		public bool bom{ get; set; }
	}
	CoolTimeFlg coolTimeFlg = new CoolTimeFlg();
	
	void Awake()
	{
		playerData.bomCoolTime = 0;
		playerData.cannonCoolTIme = 0;
		coolTimeFlg.cannon = true;
		coolTimeFlg.bom = true;
		playerData.text = GameObject.Find("Text").GetComponent<Text>();
		//シェーダーの設定
		cannonSlider.minValue = playerData.cannonCoolTIme;
		bomSlider.minValue    = playerData.bomCoolTime; 
	}
	
	//撃っているときクールタイムが増える処理＆オーバーヒートされた時
	void Bullet()
	{
		//機銃
		if (coolTimeFlg.cannon == true )
		{
			//10秒
			playerData.cannonCoolTIme += Time.deltaTime * 10f;
			if (playerData.cannonCoolTIme >= 100)
			{
				coolTimeFlg.cannon = false;
			}
		}
		//ボム
		if ( coolTimeFlg.bom == true )
		{
			playerData.bomCoolTime = 100;
			coolTimeFlg.bom = false;
		}
	}
	
	void CoolTime()
	{
		//機銃
		if ( coolTimeFlg.cannon == false) 
		{
			//5秒
			playerData.cannonCoolTIme -= Time.deltaTime * 20f;
			if (playerData.cannonCoolTIme <= 0) 
			{
				playerData.cannonCoolTIme = 0;
				coolTimeFlg.cannon = true;
			}
		}  
		//ボム
		if ( coolTimeFlg.bom == false) 
		{
			//20秒
			playerData.bomCoolTime -= Time.deltaTime * 5f;
			if (playerData.bomCoolTime <= 0) 
			{
				playerData.bomCoolTime = 0;
				coolTimeFlg.bom = true;
			}
		}
	}
	//表示
	void Draw(){
		cannonSlider.value = playerData.cannonCoolTIme;
		bomSlider.value = playerData.bomCoolTime;
		playerData.text.text = "×"+playerData.beacon;
	}
}
