using UnityEngine;
using System.Collections;

public class EnemyFactory : MonoBehaviour {
	Vector3 enemyTypeShotPos;//射撃型の生成位置

	public void Create(string ss , Vector3 enemyPos){
		switch (ss) {
			//3D 側の敵
		case "3Denemy1":	//射撃型
			Instantiate (ResourcesManager.Instance.GetResourceScene("enemy1"), enemyPos, transform.rotation);
			break;
		case "3Denemy2":	//特高型
			enemyTypeShotPos = new Vector3 (Random.Range (-5, 6), Random.Range (0, 10), 20);
			Instantiate (ResourcesManager.Instance.GetResourceScene("EnemyTypeShot"), enemyPos, transform.rotation);
			break;
			//2D 側の敵
		case "2Denemy1":
			Instantiate (ResourcesManager.Instance.GetResourceScene("enemy1"), enemyPos, transform.rotation);
			break;
		case "2Dnenmy2":
			Instantiate (ResourcesManager.Instance.GetResourceScene("enemy1"), enemyPos, transform.rotation);
			break;

		case "medium1": //中ボス
			Instantiate (ResourcesManager.Instance.GetResourceScene("EnemyTypeMedium"), enemyPos, transform.rotation);
			break;
		case "boss1": //大ボス
			Instantiate (ResourcesManager.Instance.GetResourceScene("EnemyTypeBoss"), enemyPos, transform.rotation);
			break;
		}
	}
}
