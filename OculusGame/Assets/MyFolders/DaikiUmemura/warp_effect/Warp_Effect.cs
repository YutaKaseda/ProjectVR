/// <summary>
/// Warp_ effect
/// 使用方法 カメラにAddComponent
/// 用途 ワープによるフェードイン、アウト
/// 2016/02/04 梅村大樹 作成
/// </summary>

using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
public class Warp_Effect : MonoBehaviour {
	
	ScreenOverlay screenOver;
	// Update is called once per frame
	void Update () {
		//仮当て
		if (Input.GetKeyDown (KeyCode.S)) {
			FadeWhite ();
		}
	}
	/// <summary>
	/// 他でただただ呼び出せば、フェードインアウトします
	/// </summary>
	public void FadeWhite(){
		gameObject.AddComponent <ScreenOverlay>();
		screenOver = GetComponent<ScreenOverlay>();
		screenOver.overlayShader = Shader.Find ("Hidden/BlendModesOverlay");
		StartCoroutine ("FadeWhiteCol");
	}

	IEnumerator FadeWhiteCol(){
		while(screenOver.intensity < 2f){
			screenOver.intensity += 4f * Time.deltaTime;	
			yield return null;
		}
		while(screenOver.intensity > 0){
			screenOver.intensity -= 4f * Time.deltaTime;
			yield return null;
		}

		Destroy (GetComponent<ScreenOverlay>());
	}

	IEnumerator FadeBlackCol(){
		while(screenOver.intensity > -2f){
			screenOver.intensity -= 4f * Time.deltaTime;	
			yield return null;
		}
		while(screenOver.intensity < 0){
			screenOver.intensity += 4f * Time.deltaTime;
			yield return null;
		}
	}
}
