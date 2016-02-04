using UnityEngine;
using System.Collections;

public class BulletStandard : MonoBehaviour {

	//弾のスピード
	float bulletSpeed;
	Vector3 direction;

	// 初期化
	void Awake(){
		bulletSpeed = 3000.0f;
		ShotBullet ();
	}
    
	void OnTriggrEnter(Collision collision){
		if (gameObject.CompareTag("Bucn")) {
			//Debug.Log("BulletChangeTest");
			if(gameObject.layer == LayerMask.NameToLayer("2DLayer")){
                gameObject.layer = LayerMask.NameToLayer("3DLayer");
            }
            else if (gameObject.layer == LayerMask.NameToLayer("3DLayer"))
            {
                gameObject.layer = LayerMask.NameToLayer("2DLayer");
			}
		}
	}

	//弾が前に動く
    void ShotBullet()
    {
		direction = transform.forward * bulletSpeed;
		GetComponent<Rigidbody> ().AddForce (direction);
	}
}
