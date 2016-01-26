using UnityEngine;
using System.Collections;

public class CollisionBoss : MonoBehaviour {

	ScoreManager scoreManager;
    public int bossHP { get; private set; }

    void Awake()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        bossHP = 2000;
    }
    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            //プレイヤーの弾に当たったら
            case "Player2DBullet":
                scoreManager.plusScore(1000);
                Destroy(gameObject);
                break;

            case "Player3DBullet":
                //SoundPlayer.Instance.PlaySoundEffect("Explosion",0.1f);
                scoreManager.plusScore(1000);
                bossHP -= 5;

                if (bossHP <= 0)
                {
                    Destroy(gameObject);
                }
                break;
            default:
                break;
        }

    }
}
