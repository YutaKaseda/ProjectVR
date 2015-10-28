using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {

    public int playerHP { get; private set; }
    //float move_speed; 暫定

    public void Awake(){
        playerHP = 100;
    }

    //ダメージ処理
    public virtual void Damege(int gensyo)
    {
        playerHP -= gensyo;
    }

}
