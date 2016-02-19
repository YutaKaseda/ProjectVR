using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CountDownUI : MonoBehaviour {

    [SerializeField]
    List<Text> countDownText;

    void Awake(){
        foreach (var text in countDownText){
            text.text = "Wait";
        }
    }

    public void TextUpdate(string countText){

        foreach (var text in countDownText){
            text.text = countText;
        }

    }
	
}
