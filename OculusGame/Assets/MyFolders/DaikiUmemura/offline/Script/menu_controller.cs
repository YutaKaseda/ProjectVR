using UnityEngine;
using System.Collections;
using GameMainData;
//[RequireComponent(typeof(Animator))]

public class menu_controller : MonoBehaviour 
{
	//Animator animator; //アニメーター用変数
	int      lkey;
	int      rkey;
	int      count;//何を選択中か
	int 	 moveCount;//動ききるまでのcount
	float AxisY;
	void Awake () 
	{
		//animator = GetComponent<Animator> ();
		lkey     = Animator.StringToHash ("Lkey");
		rkey     = Animator.StringToHash ("Rkey");
		count = 0;
	}
	void Update () 
	{
		AxisY = Input.GetAxisRaw("HorizontalP1");
		Debug.Log (count);
		if ((Input.GetKeyUp (KeyCode.RightArrow) || AxisY > 0.1f )&& moveCount == 0) 
		{
			moveCount = 120;
			count++;
		} 
		else if ((Input.GetKeyUp(KeyCode.LeftArrow) || AxisY < -0.1f) && moveCount == 0) 
		{
			moveCount = -120;
			count--;
		}
		else if((Input.GetKeyUp(KeyCode.Return) || Input.GetButtonUp("MaruP1")) && moveCount == 0){
			if(count == 0){
				GameData.nextState = OfflineStatus.E_OFFLINE_STATE.CUSTOMIZE;
			}
			if(count == 1){
				GameData.nextState = OfflineStatus.E_OFFLINE_STATE.RANKING;
			}
			if(count == 2){
				GameData.nextState = OfflineStatus.E_OFFLINE_STATE.OPTION;
			}
		}

		if (moveCount > 0) {
			moveCount -= 5;
			transform.Rotate(0,5,0);
		}
		if (moveCount < 0) {
			moveCount += 5;
			transform.Rotate(0,-5,0);
		}

		if (count < 0) {
			count = 2;
		}
		if(count > 2){
			count = 0;
		}
	}
}
