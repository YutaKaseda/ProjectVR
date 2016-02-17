// 2/17:Damage関数に処理追加 by石田
using UnityEngine;
using System.Collections;

public class EnemyData : MonoBehaviour
{
    public int enemyHP { get; private set; }             //EnemyのHP

    //体力初期化
    public void InitHP(int hp)
    {
        enemyHP = 100;
    }

    //ダメージ処理
    public void Damage(int gensyo)
    {
        enemyHP -= gensyo;
        //ResourcesManager使用可能次第コメント解除してください
        //EffectFactory.Instance.Create("hit", transform.position, transform.rotation);
    }
}
