using UnityEngine;
using System.Collections;

public class EnemyData : MonoBehaviour {

    public Vector3 createPos { get; set; }               //生成された位置を記録
    public Vector3 movePos { get; set; }                 //移動先の位置
    public int stopTime { get; set; }                    //射撃停止秒数
    public float enemyBulletRapid { get; set; }          //敵のたまの連射間隔
    public Transform player2DPosition { get; set; }      //追尾弾用
    public Transform player3DPosition { get; set; }      //追尾弾用
    public Vector3 targetPlayerVec { get; set; }         //Playerの位置保存場所
    public GameObject targetPlayerObject { get; set; }   //EnemyBullet保存場所
    public int enemyHP { get; private set; }                     //EnemyのHP

    //体力初期化
    public void InitHP(int hp)
    {
        enemyHP = hp;
    }

    //ダメージ処理
    public void Damege(int gensyo)
    {
        enemyHP -= gensyo;
    }

}
