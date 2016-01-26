using UnityEngine;
using System.Collections;
//２Dのベースビーコンの設置　２Dの移動の所に入れてくさい
public class Installation : MonoBehaviour {

	[SerializeField]
	Player3D P3d;


	public GameObject prefab;



	/*	if (ボタン処理) {
			BaseBeacon();
		}
*/
	

	
	//BaseBeacon設置関数
	void BaseBeacon(){
		P3d.basebeacon = transform.position;
		Instantiate(prefab,transform.position,transform.rotation);
	
	}


	
	
}