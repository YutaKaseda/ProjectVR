using UnityEngine;
using System.Collections;

public class HP : MonoBehaviour {

	public Animator animator;
	// Update is called once per frame
	void Update () {
		int i=0;
		if (Input.GetKey (KeyCode.Space)) {
			animator.SetBool("Hit", true);
			Debug.Log( "OK!" );
			i--;
		}
		if (Input.GetKey (KeyCode.A)) {
			animator.SetBool("Hit",false);
			Debug.Log( "!!!" );
			i++;
		}
		/*if(i==20){
			animator.SetBool("Hit",true);
		}
		else{
			animator.SetBool("Hit",false);
		}*/
	}
}
