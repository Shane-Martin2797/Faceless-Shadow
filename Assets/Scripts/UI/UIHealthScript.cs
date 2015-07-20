using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIHealthScript : MonoBehaviour {


	public Slider health; 

	void OnEnable(){
		PlayerController.onPlayerHealthChange += HandleOnHealthChange;
	}
	
	void OnDisable(){
		PlayerController.onPlayerHealthChange -= HandleOnHealthChange;
	}

	void HandleOnHealthChange(float healthValue){
		health.value = (healthValue);
	}
}
