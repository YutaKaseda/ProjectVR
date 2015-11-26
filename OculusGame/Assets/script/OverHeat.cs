using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OverHeat: MonoBehaviour {

	[SerializeField]
	Slider Bom;

	[SerializeField]
	Slider Cannon;

	[SerializeField]
	GameObject Player;





	void Awake(){
		Cannon.minValue = Player.GetComponent<PlayerData>().CannonGage;
		Bom.minValue = Player.GetComponent<PlayerData>().BomGage;
	 
	}
	public void Draw(){
		Bom.value = Player.GetComponent<PlayerData>().BomGage;
		Cannon.value = Player.GetComponent<PlayerData>().CannonGage;
	
	}

}


















































/*
public class OverHeat: MonoBehaviour {
	
	[SerializeField]
	Slider slider;
	
	[SerializeField]
	GameObject Player;
	
	void Awake(){
		slider.minValue = Player.GetComponent<PlayerData>().Gage;
	}
	public void Draw(){
		slider.value = Player.GetComponent<PlayerData>().Gage;
	}
}*/