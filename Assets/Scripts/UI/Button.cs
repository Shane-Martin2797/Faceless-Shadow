using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public GameController gameController;

	public void OnClick_ResetHighScores(){
		ScoreHolderScript.refreshScores ();
	}

	public void OnClick_Quit(){
#if UNITY_EDITOR
	UnityEditor.EditorApplication.isPlaying = false;
#else
	Application.Quit();
#endif
	}

	public void OnClick_PlayAgain(){
		Application.LoadLevel (Scenes.Scene_Demo);
	}
}
