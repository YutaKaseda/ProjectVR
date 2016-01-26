//突撃型途中で方向転換
using UnityEngine;
using System.Collections;
public class EnemyTypeAssault3D : MonoBehaviour {
	public Transform target; //プレイヤーの位置情報
	public float speed;
	Vector3 move;
	Vector3 movePos;//移動先の位置
	Vector3 createPos;
	void Awake () {
		target = GameObject.FindGameObjectWithTag ("Player3D").transform; //プレイヤー座標取得
		createPos = new Vector3 (target.position.x, target.position.y, target.position.z);
		movePos = new Vector3 (createPos.x, createPos.y, createPos.z+30);
		speed = 400f;
		StartCoroutine ("EnemyTypeAssaultMove");
	}
	
	//初期移動
	IEnumerator EnemyTypeAssaultMove(){
		//敵の位置を取得しプレイヤーの方を向く
		Vector3 targetPos = target.position;
		Vector3 direction = transform.position - targetPos;
		transform.rotation = Quaternion.LookRotation (direction);
		
		while (transform.position != movePos) {
			transform.position = Vector3.MoveTowards (transform.position, movePos, 0.3f);
			yield return null;
		}
		StartCoroutine ("EnemyTypeAssaultNextMove");
	}
	IEnumerator EnemyTypeAssaultNextMove(){
		//停止予定位置より後ろにいる場合一時停止して敵の位置を再取得、再移動
		Vector3 targetPos = target.position;
		Vector3 direction = transform.position - targetPos;
		transform.rotation = Quaternion.LookRotation (direction);
		yield return new WaitForSeconds (0.5f);
		move = transform.forward * speed * -6f;
		GetComponent<Rigidbody> ().AddForce (move);
		Destroy (gameObject, 5f);
		yield return null;
	}
}