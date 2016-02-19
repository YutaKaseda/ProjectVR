// 2/19 まさ 他のボス関係との結合
// 2月～19日　瀧本　基礎(TargetBullet,OnCollisionEnter);

using UnityEngine;
using System.Collections;

public class Railgun : MonoBehaviour {
	void Awake(){
		Destroy (gameObject,3f);
	}
	//方向変換
	//狙うプレイヤーのVector3	入れて呼ぶ
	public void TargetBullet(Vector3 target){
		transform.LookAt (target);
	}

	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag=="Player3D" ||collision.gameObject.tag=="Player2D") 
		{
			//ダメージ判定
		}
	}


}
