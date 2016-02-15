using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerData2D : PlayerData {

	public float resurrectionTime{ get; set; }		//復活時のクールタイム
	public float resurrectionPenalty{ get; set;}
	public float cannonCoolTIme{ get;set; }
	public float bomCoolTime{ get;set; }
	public int beacon=6;
	public Text text;
	public Vector3 moveValue;
	public float degree{ get; set;}
	[SerializeField]
	public float radius;
	public float pi{ get; set;}
	public Vector3 position;
}
