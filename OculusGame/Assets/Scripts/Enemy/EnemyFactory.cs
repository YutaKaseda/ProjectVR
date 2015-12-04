using UnityEngine;
using System.Collections;

public class EnemyFactory : MonoBehaviour {
	Vector3 enemyTypeShotPos;//射撃型の生成位置

	public void Create(string ss){
		switch (ss) {
		case "enemy01":	//特攻型
			Instantiate (ResourcesManager.Instance.GetResourceScene("EnemyTypeAttack"), transform.position, transform.rotation);
			break;
		case "enemy02":	//射撃型
			enemyTypeShotPos = new Vector3 (Random.Range (-5, 6), Random.Range (0, 10), 20);
			Instantiate (ResourcesManager.Instance.GetResourceScene("EnemyTypeShot"), enemyTypeShotPos, transform.rotation);
			break;
		case "medium01": //中ボス
			Instantiate (ResourcesManager.Instance.GetResourceScene("EnemyTypeMedium"), transform.position, transform.rotation);
			break;
		case "boss01": //大ボス
			Instantiate (ResourcesManager.Instance.GetResourceScene("EnemyTypeBoss"), transform.position, transform.rotation);
			break;
		}
	}
}
