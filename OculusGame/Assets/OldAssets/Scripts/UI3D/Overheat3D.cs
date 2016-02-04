using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Overheat3D : MonoBehaviour {

	//シェーダーの設定　同じ名前のシェーダーを設定してください
  [SerializeField]
   Slider balkanSlider;
  [SerializeField]
   Slider laserSlider;
  [SerializeField]
   Slider bombSlider;



	//forで使う変数
   int j;
	//Balkanを撃っているかのフラグ管理
	//true =　撃っている　false　= 撃っていない
   bool balkanGageMove;

	//武器の中身
    struct Weapon
	{
    public float nowBullet;
    public bool  overheat;
    public float coolTime;
    }
	//武器の数の設定
	//0=balkan; 1=laser 2=bomb
    Weapon[] weapon = new Weapon[3];

	//表示用
	Slider[] UI = new Slider[3];

	void Awake ()
	{
		//武器の中身初期化
		for (j=0; j<3; j++) 
		{
			weapon [j].nowBullet = 0;
			weapon [j].overheat = false;
        }
		balkanGageMove= false;
		//各クールタイムセット
		weapon [0].coolTime = 18f;
		weapon [1].coolTime = 2f;
		weapon [2].coolTime = 3f;
		//
		UI[0] = balkanSlider;
		UI [1] = laserSlider;
		UI [2] = bombSlider;
    }//Awake

	void Update(){
		if (Input.GetKey (KeyCode.A)) {
			Debug.Log ("a");
			Overheat (0);
		} else {
			balkanGageMove = false;
		}
		if (Input.GetKey (KeyCode.S)) {
			Overheat (1);
		} else
		if (Input.GetKey (KeyCode.D)) {
			Overheat (2);
		}


		/*
		if (weapon[0].nowBullet < 1){

		}
		if( weapon [1].nowBullet < 1 ){
			UI [1].gameObject.SetActive (false);
		}
		 if( weapon [2].nowBullet < 1) {
			UI [2].gameObject.SetActive (false);
		}*/
		BulletCoolTime ();
	}






	/*以下の武器使う時呼んでください




	balkanキーを押してる時
	Overheat (0);
	
	balkanキーを押してないとき
	balkanGageMove = false;
	
	laserのキーが押されたとき
　　 Overheat (1);

　　　bombキーが押されたとき
　　　Overheat(2);

プログラムがループしている所の最後で呼んでください
　　　BulletCoolTime ();
*/
	//オーバーヒートになるための各武器の処理
void Overheat(int BulletNo){

		UI [BulletNo].gameObject.SetActive (true);

		//武器による分岐
		switch (BulletNo){
			//Balkanの場合
		
		case 0:
			balkanGageMove = true;
			weapon [BulletNo].nowBullet += Time.deltaTime * 6f;
			if (weapon [BulletNo].nowBullet > 90)
			{
				weapon [BulletNo].overheat = true;
			}
			break;
			//laser　or bombの場合
		case 1:
		case 2:
			if(weapon[BulletNo].overheat ==false){
			weapon [BulletNo].nowBullet = 90;
			weapon [BulletNo].overheat = true;
			}
			break;
		}
		//UIの表示関数

		BulletGageDraw ();
	}
	//UI表示関数
	void BulletGageDraw()
	{
	    balkanSlider.value = weapon [0].nowBullet;
		laserSlider.value  = weapon [1].nowBullet;
		bombSlider.value   = weapon [2].nowBullet;
	}
	//各武器のクールタイムの処理
	void BulletCoolTime()
	{
		for (j=0; j<3; j++) {
			//オーバーヒートがしているときか　そのキーが押されてないとき
			if (weapon [j].overheat == true && weapon [j].nowBullet > 0 ||
				balkanGageMove == false && weapon [j].nowBullet > 0) {
				weapon [j].nowBullet -= Time.deltaTime * weapon [j].coolTime;
				if (weapon [j].nowBullet < 0) {
					weapon [j].overheat = false;
					UI [j].gameObject.SetActive (false);
				}
			}
		}
		BulletGageDraw ();
	}
}