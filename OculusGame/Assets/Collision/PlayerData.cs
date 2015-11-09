using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {

    public int playerHP { get; private set; }           //自機の体力
    public float speed  { get; set; }           //自機の移動の速さ
    public Vector3 movePlayer { get; set; }             //自機の移動
    public float vectorX { get; set; }
    public float vectorY { get; set; }
    public float vectorZ { get; set; }
    public GameObject bulletPrefab { get; set; }

    public void Awake(){
        playerHP = 100;
    }

    //ダメージ処理
    public virtual void Damege(int gensyo)
    {
        playerHP -= gensyo;
    }
}
