using UnityEngine;
using System.Collections;

public class PlayerData2D : PlayerData {
    public Vector3 laneMovePlayer{ get; set; }      //レーンの変更
    public int laneFlg { get; set; }                //今、どのレーンにいるか
    public float moveEX { get; set; }               //移動量
    public float zero { get; set; }                 //原点
    public bool inputFlg { get; set; }
	public float resurrectionTime{ get; set; }		//復活時のクールタイム
	public float resurrectionPenalty{ get; set;}


}
