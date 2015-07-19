using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UITimerScript : MonoBehaviour {

	public Text text, textBackground; 
	void OnEnable(){
		GameController.onTimerValueChange += HandleOnTimerChange;
	}
	
	void OnDisable(){
		GameController.onTimerValueChange -= HandleOnTimerChange;
	}

	void HandleOnTimerChange(float value){
		float timerMinutes = Mathf.FloorToInt(value / 60);
		float timerSeconds = Mathf.Floor(value % 60);
		if (timerSeconds > 59) {
			timerMinutes += 1;
			timerSeconds = 0;
		}
		updateText (timerMinutes, timerSeconds);
	}
	void updateText(float minutes, float seconds){
		string textProper = minutes.ToString ("0") + ":" + seconds.ToString ("00");
		text.text = textProper;
		textBackground.text = textProper;
	}
}
