// 2/19 梅村 ボスのあたり判定
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CollisionBoss : MonoBehaviour {

	BossData bossData;

    void Awake()
    {
		bossData = GetComponent<BossData>();
    }

	void OnTriggerEnter(Collider other){
		switch (other.gameObject.tag) {
			
		case "Player2DBullet":
			bossData.BossDamage("NormalBullet","2D");
			if (bossData.bossHp <= 0) {
				Destroy (gameObject);
			}
			break;
		}
	}
}
