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
}
