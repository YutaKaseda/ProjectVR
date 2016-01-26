using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//特殊弾(Missile or beacon)
public class SpecialBullets
{
	//オーバーヒートまでの時間
	public float nowBullst;
	//オーバーヒートしてるかどうか
	//true = している　false = してない
	public bool  overheat;
	public SpecialBullets(){nowBullst =0;overheat = false;}
}
public class LiveBullets :SpecialBullets{
	//　武器レベル
	public int level;
	//現在使われているか
	public bool useWeapon;
	public LiveBullets(){level = 1;useWeapon = false;}
}


public class OverHeat2D: MonoBehaviour {

	//シェーダー
	[SerializeField]
	Slider balkanSlider;
	[SerializeField]
	Slider laserSlider;
	[SerializeField]
	Slider missileSlider;
	[SerializeField]
	Slider beaconSlider;
	//ウィンドウの設定(色変化の使用)
	[SerializeField]
	Image BSelection;

	[SerializeField]
	Image LSelection;
	//武器番号
	int weaponNo;
	//forを回すための変数
	int j;
	//色は適当
	Color pattern1 = new Color (1f,0f,0f,1f);
	Color pattern2 = new Color (0f, 0f, 0f,0f);
	//二つのクラス配列の準備
	SpecialBullets[] specialBullets = new SpecialBullets[2];
	LiveBullets[] liveBullets =new LiveBullets[2];
	
	void Awake () {
		//変数の初期化
		weaponNo = 0;
		BSelection.color = pattern1;
		LSelection.color = pattern2;
		for (int j=0; j<2; j++) {
			specialBullets [j] = new SpecialBullets ();
			liveBullets [j] =new LiveBullets();
		}
	}

	//以下の武器を使用した場合以下の関数を呼んでくさい

/* 武器入れ替え
   WeaponChange();

   //実弾(Balkan or laser)撃っているとき
   OverHeat (weaponNo);

  //実弾(Balkan or laser)撃っていないとき
  liveBullets[weaponNo].useWeapon = false;

  //特殊弾(Missile)撃っているとき
   OverHeat(2);

 //特殊弾(beacon)設置した場合
  OverHeat(3);

　　ループしている所の最後あたりで
   BulletCoolTime();
   */
  
	/*void Update () {
		if (Input.GetKeyDown(KeyCode.A)) {
			WeaponChange();
		}

		if (Input.GetKey (KeyCode.Z)) {
			OverHeat (weaponNo);
		} else {
			liveBullets [weaponNo].useWeapon = false;
		}
		
		if (Input.GetKey (KeyCode.X)) {
			OverHeat (2);
		}
		if (Input.GetKey (KeyCode.C)) {
			OverHeat(3);
		}
		BulletCoolTime ();

	}*/

	//武器切り替え
	void WeaponChange(){
		//バルカンの場合		
		if (weaponNo == 0) {
			liveBullets[weaponNo].useWeapon= false;
			BSelection.color =pattern2;
			LSelection.color =pattern1;
			weaponNo = 1;	
			//レーザーの場合
		} else {
			liveBullets[weaponNo].useWeapon = false;
			LSelection.color = pattern2;
			BSelection.color = pattern1;
			weaponNo = 0;
		}
	}
	//オーバーヒートするための処理
	public void OverHeat(int number)
	{

		//実弾でオーバーヒートしてない場合
		if (number == 0 && liveBullets[number].overheat == false || 
		    number == 1 && liveBullets[number].overheat == false) {
			//現在の実弾を使っているフラグを立てる
			liveBullets[number].useWeapon =true;
			//レベルよるオーバーヒート時間の変化
			switch(liveBullets[number].level)
			{
			case 1:
				liveBullets[number].nowBullst +=Time.deltaTime * 12f;

				break;
			case 2:
				//BalkanとLaserのオーバーヒート時間が違うため
				if (number == 0) 
				{
					liveBullets[number].nowBullst += Time.deltaTime * 6f;
				} else if (number == 1)
				{
					liveBullets[number].nowBullst += Time.deltaTime * 12f;
				}
				break;
			case 3:
				liveBullets[number].nowBullst += Time.deltaTime * 6f;
				break;
			}
			//オーバーヒートする場合
			if(liveBullets[number].nowBullst >= 60){
				liveBullets[number].overheat = true;
			}
			//特殊弾(Missile　or　beacon)でオーバーヒートしてない場合
		}else if(number == 2 && specialBullets[number-2].overheat == false ||
		         number == 3 && specialBullets[number-2].overheat == false){

			specialBullets[number-2].overheat = true;
		    specialBullets[number-2].nowBullst = 60;
	}
		//UIに表示
		BulletGageDraw();
}
	//UIの表示
	void BulletGageDraw()
	{
		balkanSlider.value = liveBullets [0].nowBullst;
		laserSlider.value = liveBullets [1].nowBullst;
		missileSlider.value = specialBullets [0].nowBullst;
		beaconSlider.value = specialBullets [1].nowBullst;
	}
	//各クールタイムの処理
	public void BulletCoolTime(){
		for (j=0; j<2; j++) {
			//実弾(laser　or Balkan) がオーバーヒートしてるか　撃っていないとき
			if (liveBullets [j].overheat == true && liveBullets [j].nowBullst > 0  ||
			    liveBullets [j].useWeapon == false && liveBullets [j].nowBullst > 0) {

				//実弾のレベルによるクールタイムの変化
				switch (liveBullets [j].level) {
				case 1:
					liveBullets [j].nowBullst -= Time.deltaTime * 30f;
					break;
				case 2:
					//BalkanとLaserのオーバーヒート時間が違うため
					if (j == 0) {
						liveBullets [j].nowBullst -= Time.deltaTime * 15f;
					} else if (j == 1) {
						liveBullets [j].nowBullst -= Time.deltaTime * 30f;
					} 
					break;
				case 3:
					liveBullets [j].nowBullst -= Time.deltaTime * 12f;
					break;
				}
				//オーバーヒート時間が終了したら
				if (liveBullets [j].nowBullst <= 0) {
					liveBullets [j].overheat = false;
				}
			} 
			//特殊弾のオーバーヒートの時
			if (specialBullets[j].overheat == true) {
				specialBullets[j].nowBullst -= Time.deltaTime *2f;
				if (specialBullets [j].nowBullst <= 0) {
					specialBullets[j].overheat = false;
				}
			}
		}
		//UI表示
		BulletGageDraw ();
	}
}
