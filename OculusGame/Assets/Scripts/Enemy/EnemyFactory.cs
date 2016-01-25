using UnityEngine;
using System.Collections;

public class EnemyFactory : MonoBehaviour {

	public void Create(string ss , Vector3 enemyPos){
		switch (ss) {
			//3D 側の敵
		case "3Denemy1":	//射撃型
			Instantiate (ResourcesManager.Instance.GetResourceScene("3Denemy1"), enemyPos, transform.rotation);
			break;
        case "3Denemy1move":	//射撃型
            Instantiate(ResourcesManager.Instance.GetResourceScene("3Denemy1move"), enemyPos, transform.rotation);
            break;
        case "3Denemy1updown":	//射撃型
            Instantiate(ResourcesManager.Instance.GetResourceScene("3Denemy1updown"), enemyPos, transform.rotation);
            break;
		case "3Denemy2":	//特高型
			Instantiate (ResourcesManager.Instance.GetResourceScene("3Denemy2"), enemyPos, transform.rotation);
			break;
			//2D 側の敵
		case "2Denemy1":
			Instantiate (ResourcesManager.Instance.GetResourceScene("2Denemy1"), enemyPos, transform.rotation);
			break;
        case "2Denemy1Foward":
            Instantiate(ResourcesManager.Instance.GetResourceScene("2Denemy1Foward"), enemyPos, transform.rotation);
            break;
        case "2Denemy1updown":
            Instantiate(ResourcesManager.Instance.GetResourceScene("2Denemy1updown"), enemyPos, transform.rotation);
			break;
        case "2Denemy1W":
            Instantiate(ResourcesManager.Instance.GetResourceScene("2Denemy1W"), enemyPos, transform.rotation);
            break;
        case "2Denemy1Z":
            Instantiate(ResourcesManager.Instance.GetResourceScene("2Denemy1Z"), enemyPos, transform.rotation);
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
