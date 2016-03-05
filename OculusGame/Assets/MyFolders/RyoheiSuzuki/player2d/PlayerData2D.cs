// 2/16:class内容整理 by鈴木
// 2/16:class内容追加 by瀧本
// 2016/02/18 鈴木
// class内容変更
// 2016/03/04 梅村　ミサイル関連追加
using UnityEngine;
using System.Collections;

public class PlayerData2D : PlayerData {
	[SerializeField]
	public float intervalTime;	//弾を撃てるようになるまでの時間
	public float shotWaitTime { get; set;}	//現在待機してる時間
	public float missileIntervalTime;	//missileを撃てるようになるまでの時間
	public float missileWaitTime { get; set;}	//現在待機してる時間
	public float resurrectionTime{ get; set; }		//復活時のクールタイム
	public float degree{ get; set;}
	[SerializeField]
	public float radius;
	public float pi{ get; set;}
	public Vector3 position;
	public int lifes{ get; set; }
	public int weaponLevel { get; set;}

}
