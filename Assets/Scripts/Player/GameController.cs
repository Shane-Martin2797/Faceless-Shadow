using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {



	// Use this for initialization
	void Awake () {
		Application.LoadLevelAdditive (Scenes.Scene_HUD);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
