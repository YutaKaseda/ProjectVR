using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : SingletonMonobehaviour<GameManager> {

	[SerializeField]
	List<GameObject> initializeObjects;

	[SerializeField]
	bool dontDestroyOnLoad;

	void Awake(){

		if(dontDestroyOnLoad)
	        DontDestroyOnLoad(gameObject);

		foreach(GameObject prefab in initializeObjects){
			var obj = Instantiate(prefab) as GameObject;
			obj.transform.parent = transform;
		}
	}
}
