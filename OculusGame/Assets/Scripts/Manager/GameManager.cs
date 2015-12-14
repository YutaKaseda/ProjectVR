using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : SingletonMonobehaviour<GameManager> {

	[SerializeField]
	List<GameObject> initializeObjects;

	void Awake(){

        //�V�[���X�V���ɍ폜���ꂽ��Q�[���~�܂�̂�
        DontDestroyOnLoad(gameObject);

		foreach(GameObject prefab in initializeObjects){
			var obj = Instantiate(prefab) as GameObject;
			obj.transform.parent = transform;
		}
	}
}
