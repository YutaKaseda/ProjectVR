/// <summary>
/// Warp_ effect
/// 使用方法 カメラにAddComponent
/// 用途 ワープによるフェードイン、アウト
/// 2016/02/04 梅村大樹 作成
/// </summary>

using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
public class WarpEffect : MonoBehaviour {
	
    [SerializeField]
	ScreenOverlay screenOver;
	//透明度
	[SerializeField]
	float whiteAlpha,blackAlpha,damageAlpha;
	//フェード時間
	[SerializeField]
	float fadeTimer;

	public bool activeWarp{private set;get;}

	public Texture2D damageImg;
	void Awake(){
		whiteAlpha = 2f;
		blackAlpha = -2f;
		damageAlpha = 1f;
		fadeTimer = 4f;
		activeWarp = false;
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.A)){
			FadeDamage();
		}
	}

	/// <summary>
	/// 他でただただ呼び出せば、フェードインアウトします
	/// </summary>
	public void FadeWhite(){
        if (!screenOver.enabled){
            screenOver.enabled = true;
            screenOver.overlayShader = Shader.Find("Hidden/BlendModesOverlay");
            activeWarp = !activeWarp;
            StartCoroutine("FadeWhiteCol");
        }
	}

	public void FadeBlack(){
        if (!screenOver.enabled){
            screenOver.enabled = true;
            screenOver.overlayShader = Shader.Find("Hidden/BlendModesOverlay");
            activeWarp = !activeWarp;
            StartCoroutine("FadeBlackCol");
        }
	}

	public void FadeDamage(){
		if (!screenOver.enabled){
			screenOver.enabled = true;
			screenOver.texture = damageImg;
			screenOver.overlayShader = Shader.Find("Hidden/BlendModesOverlay");
			activeWarp = !activeWarp;
			StartCoroutine("FadeDamageCol");
		}
	}

	IEnumerator FadeWhiteCol(){
		while(screenOver.intensity < whiteAlpha){
			screenOver.intensity += fadeTimer * Time.deltaTime;	
			yield return null;
		}
		activeWarp = !activeWarp;
		while(screenOver.intensity > 0){
			screenOver.intensity -= fadeTimer * Time.deltaTime;
			yield return null;
		}

        screenOver.enabled = false;
	}

	IEnumerator FadeBlackCol(){
		while(screenOver.intensity > blackAlpha){
			screenOver.intensity -= fadeTimer * Time.deltaTime;	
			yield return null;
		}
		activeWarp = !activeWarp;
		while(screenOver.intensity < 0){
			screenOver.intensity += fadeTimer * Time.deltaTime;
			yield return null;
		}

        screenOver.enabled = false;
	}

	IEnumerator FadeDamageCol(){
		while(screenOver.intensity < damageAlpha){
			screenOver.intensity += fadeTimer * Time.deltaTime;	
			yield return null;
		}
		activeWarp = !activeWarp;
		while(screenOver.intensity > 0){
			screenOver.intensity -= fadeTimer * Time.deltaTime;
			yield return null;
		}
		screenOver.texture = null;
		screenOver.enabled = false;
	}
}
