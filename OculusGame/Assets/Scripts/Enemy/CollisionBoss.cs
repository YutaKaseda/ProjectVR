using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CollisionBoss : MonoBehaviour {

	ScoreManager scoreManager;
    public int bossHP { get; private set; }

    public Text gameState;

    void Awake()
    {
        //scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        bossHP = 10000;
    }
    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            //プレイヤーの弾に当たったら
            case "Player2DBullet":
                //SoundPlayer.Instance.PlaySoundEffect("Explosion",0.1f);
                //scoreManager.plusScore(1000);
                bossHP -= 5;
                Debug.Log("HP:" + bossHP);
                if (bossHP <= 0)
                {
                    Destroy(gameObject);
                    Application.Quit();
                }
                break;

            case "Player3DBullet":
                //SoundPlayer.Instance.PlaySoundEffect("Explosion",0.1f);
                //scoreManager.plusScore(1000);
                bossHP -= 5;
                Debug.Log("HP:"+bossHP);
                if (bossHP <= 0)
                {
                    Destroy(gameObject);
                    Application.Quit();
                }
                break;
            default:
                break;
        }

    }
}
