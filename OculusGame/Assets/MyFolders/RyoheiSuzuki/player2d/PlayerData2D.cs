// 2/16:class内容整理 by鈴木
// 2/16:class内容追加 by瀧本
using UnityEngine;
using System.Collections;

public class PlayerData2D : PlayerData {

	public float resurrectionTime{ get; set; }		//復活時のクールタイム
	public float resurrectionPenalty{ get; set;}
	public Vector3 moveValue;
	public float degree{ get; set;}
	[SerializeField]
	public float radius;
	public float pi{ get; set;}
	public Vector3 position;
	public int lifes;
	public int weaponLevel;
}
