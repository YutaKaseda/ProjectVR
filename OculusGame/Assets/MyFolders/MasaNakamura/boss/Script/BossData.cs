// 2/19 梅村 ボスのデータ
using UnityEngine;
using System.Collections;

public class BossData : MonoBehaviour {
	public const int target2D = 1;
	public const int target3D = 2;

	public int bossHp { private set; get;}
	public int bossHate { set; get;}//+10で2Dを狙う -10で3Dを狙う
	public int bossAttackTarget { set; get;}

	void Awake(){
		bossHp = 400;
		bossAttackTarget = target2D;
	}
	/// <summary>
	/// ダメージ処理
	/// </summary>
	/// <param name="bullet">弾の種類</param>
	/// <param name="player">攻撃しているプレイヤー</param>
	public void BossDamage(string bullet,string player){
		Debug.Log (player + "ダメージ");

		switch(bullet){
		case "NomalBullet":
			bossHp -= 2;
			break;
		default:
			Debug.LogError("bullet指定ミス");
			break;
		}

		switch(player){
		case "2D":
			bossHate++;
			break;
		case "3D":
			bossHate--;
			break;
		default:
			Debug.LogError("player指定ミス");
			break;
		}

		if(bossHate >= 10){
			bossAttackTarget = target2D;
			bossHate = 0;
		}
		if(bossHate <= -10){
			bossAttackTarget = target3D;
			bossHate = 0;
		}
	}
}