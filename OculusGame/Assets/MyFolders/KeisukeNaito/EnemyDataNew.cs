﻿/// <summary>
/// Enemy data new.
/// 用途　Enemyの変数等の管理
/// 使用方法　EnemyのPrefabに入れて行動をさせるクラスから参照する（基本してある）
/// 2/16 内藤　作成
/// 2/18 内藤　追記（追尾等）
/// </summary>

using UnityEngine;
using System.Collections;

public class EnemyDataNew : MonoBehaviour {
	
	public Vector3 movePos{ get; set; }   				//移動先の位置
    public int enemyHP { get; private set; }            //EnemyのHP
	public float enemyDegree{ get; set; } 				//移動時に使う角度
	public float enemyRadius{ get; set; } 				//移動時に使う半径
	public float enemyDeleteTime{ get; set;}			//敵を消す時間
	public float enemyLifeTime{ get; set;}				//敵が生存している時間

	public float playerEnemyDistance{ get; set;}		//2点間の距離保存用
	public float stokingX{ get; set;}					
	public float stokingY{ get; set;}					//追尾用座標調整保存変数
	public float stokingZ{ get; set;}
	public bool stokingSearch{ get; set; }				//追尾用範囲内にいるかどうか

	public float enemySpeed{ get; set;}
	public float player2DDegree{ get; set; }			//Speed格納仮変数

	public float pi{ get; private set;}

	void Awake(){
		pi = 3.14f;
	}

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