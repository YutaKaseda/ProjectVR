/// <summary>
/// Warp_ effect
/// 使用方法 カメラにAddComponent
/// 用途 ワープによるフェードイン、アウト
/// 2016/02/04 梅村大樹 作成
/// 2016/3/3 フェードのバグ直し
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

	/// <summary>
	/// 他でただただ呼び出せば、フェードインアウトします
	/// </summary>
	public void FadeWhite(){
		FadeInit ();
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
			if(activeWarp){
				yield break;
			}
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
			if(activeWarp){
				yield break;
			}
			yield return null;
		}

        screenOver.enabled = false;
	}

	IEnumerator FadeDamageCol(){
		while(screenOver.intensity < damageAlpha){
			screenOver.intensity += fadeTimer * Time.deltaTime;	
			if(activeWarp){
				yield break;
			}
			yield return null;
		}
		while(screenOver.intensity > 0){
			screenOver.intensity -= fadeTimer * Time.deltaTime;
			if(activeWarp){
				yield break;
			}
			yield return null;
		}
		screenOver.texture = null;
		screenOver.enabled = false;
	}

	public void FadeInit(){
		screenOver.texture = null;
		screenOver.intensity = 0;
		screenOver.enabled = false;
	}
}
