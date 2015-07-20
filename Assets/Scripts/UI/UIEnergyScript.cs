using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIEnergyScript : MonoBehaviour {

	public Slider energy;

	void OnEnable(){
		PlayerController.onPlayerEnergyChange += HandleOnEnergyChange;
	}
	
	void OnDisable(){
		PlayerController.onPlayerEnergyChange -= HandleOnEnergyChange;
	}
	
	void HandleOnEnergyChange(float energyValue){
		energy.value = (energyValue);
	}

}
