using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : SingletonMonobehaviour<GameManager> {

	[SerializeField]
	List<GameObject> initializeObjects;

	void Awake(){
		foreach(GameObject prefab in initializeObjects){
			var obj = Instantiate(prefab) as GameObject;
			obj.transform.parent = transform;
		}
	}
}
