using UnityEngine;
using System.Collections;
using BarrierStatus;

public class PlayerData2D : PlayerData {

	public float resurrectionTime{ get; set; }		//復活時のクールタイム
	public float resurrectionPenalty{ get; set;}

    //becon.barrier関係
    public bool putFlg { get; set; }
    public bool moveFlg { get; set; }
    public bool penaltyFlg { get; set; }
    public float time { get; set; }
    public float interval { get; set; } //ビーコンを置いた後のインターバル
    public float waitTime { get; set; } //ビーコンを置くのに必要な時間
    public float penaltyTime { get; set; } //ビーコンを置いているときにボタンを離した時のペナルティタイム
    public BarrierState barrierFlg { get; set; }
}
