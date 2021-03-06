﻿// 2/19 梅村 ボスのあたり判定
// 2016/03/6 梅村 必殺技のあたり判定
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

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
			break;
		case "SpecialArts":
			bossData.BossDamage("SpecialArts","2D");
			break;
		}
	}
}
