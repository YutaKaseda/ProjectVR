using UnityEngine;
using System.Collections;

public class EnemyTypeAttack : MonoBehaviour {

	Animation anim;
	
	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animation> ();
		AnimPlay();
	}
	
	// Update is called once per frame
	void AnimPlay () {
		anim.Play ("EnemyTypeAttackAnim");
	}

	void Delete(){
		Destroy(gameObject);
	}
}
