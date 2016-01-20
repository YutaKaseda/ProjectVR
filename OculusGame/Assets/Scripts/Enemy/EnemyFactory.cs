using UnityEngine;
using System.Collections;

public class EnemyFactory : MonoBehaviour {

	public void Create(string ss , Vector3 enemyPos){
		switch (ss) {
			//3D 側の敵
		case "3Denemy1":	//射撃型
			Instantiate (ResourcesManager.Instance.GetResourceScene("enemy1"), enemyPos, transform.rotation);
			break;
        case "3Denemy1move":	//射撃型
            Instantiate(ResourcesManager.Instance.GetResourceScene("enemy1move"), enemyPos, transform.rotation);
            break;
        case "3Denemy1updown":	//射撃型
            Instantiate(ResourcesManager.Instance.GetResourceScene("enemy1updown"), enemyPos, transform.rotation);
            break;
		case "3Denemy2":	//特高型
			Instantiate (ResourcesManager.Instance.GetResourceScene("enemy2"), enemyPos, transform.rotation);
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
