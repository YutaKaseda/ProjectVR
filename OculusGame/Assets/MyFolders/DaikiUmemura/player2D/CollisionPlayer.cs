//2016/2/29 梅村 作成 くらった処理追加
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class CollisionPlayer : MonoBehaviour {
	
	PlayerData playerData;
	Animator damageAnim;
	void Awake()
	{
		playerData = GetComponent<PlayerData>();
		damageAnim = GetComponent<Animator>();
	}
	
	void OnTriggerEnter(Collider other){
		switch (other.gameObject.tag) {
		case "Enemy":
			damageAnim.SetBool("damage",true);
			playerData.Damage(1);
			break;
		}
	}

	void OnTriggerStay(Collider other){
		switch (other.gameObject.tag) {
		case "Railgun":
			damageAnim.SetBool ("damage", true);
			playerData.Damage (1);
			break;
		}
	}
	public void DamageAnimEnd(){
		damageAnim.SetBool("damage",false);
	}
}
