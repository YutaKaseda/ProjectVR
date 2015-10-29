using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HPBar: MonoBehaviour {

	[SerializeField]
	Slider slider;

	[SerializeField]
	GameObject Player;

	void Awake(){
		slider.maxValue = Player.GetComponent<PlayerData>().HP;
	}
	public void Draw(){
		slider.value = Player.GetComponent<PlayerData>().HP;
	}
}
