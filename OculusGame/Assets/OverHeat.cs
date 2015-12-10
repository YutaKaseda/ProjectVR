using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class OverHeat: MonoBehaviour {
	
	[SerializeField]
	PlayerData2D playerData;

	[SerializeField]
	Text text;

	public	int beacon=6;

	public struct CoolTimeFlg{
		public float bom{ get; set;}
		public float cannon{ get; set;}
	}
	CoolTimeFlg coolTimeFlg = new CoolTimeFlg();
	void Awake()
	{
		playerData.cannonCoolTime = 0;
		playerData.bomCoolTime = 0;
		coolTimeFlg.cannon = true;
		coolTimeFlg.bom = true;
	    Cannon.minValue = cannonCoolTIme;
	    Bom.minValue = bomCoolTime; 
	 

	}

	public void Bullet()
	{
		if (coolTimeFlg.cannon == true )
		{
			playerData.cannonCoolTime += Time.deltaTime * 10f;
			if (playerData.cannonCoolTime >= 100)
			{
				coolTimeFlg.cannon = false;
			}
		}
		if (coolTimeFlg.bom == true )
		{
			playerData.bomCoolTime = 100;
			coolTimeFlg.bom = false;
		}
	}
	
	public void CoolTime()
	{
		if (coolTimeFlg.cannon == false) 
		{
			playerData.cannonCoolTime -= Time.deltaTime * 20f;
			if (playerData.cannonCoolTime <= 0) 
			{
				playerData.cannonCoolTime = 0;
				coolTimeFlg.cannon = true;
			}
		}  
		if (coolTimeFlg.bom == false) 
		{
			playerData.bomCoolTime -= Time.deltaTime * 5f;
			if (playerData.bomCoolTime <= 0) 
			{
				playerData.bomCoolTime = 0;
				coolTimeFlg.bom = true;
			}
		}

	}
public void Draw(){
	  Cannon.value = cannonCoolTIme;
	  Bom.value = bomCoolTime;
		text.text = "×"+beacon;
	}
}

	

