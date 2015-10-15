using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float ShotMove(float bulletSpeed){

		GetComponent<Rigidbody>().velocity += new Vector3(bulletSpeed,0,0);
		return 0;
	}
}
