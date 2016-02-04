using UnityEngine;
using System.Collections;

public class Collisionbullet : MonoBehaviour {

    //当たらなくても5秒後には消えるように
    void Awake()
    {
        Destroy(gameObject,5);
    }

    //何かに当たったら消える
	void OnTriggerEnter(Collider other){
		switch (other.tag) {
            case "2DEnemy":
            case "3DEnemy":
			Destroy (gameObject);
			break;
		}
	}
}