using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static event System.Action<float> onTimerValueChange;

	public float timer;
	private float timerDefault = 240;
	private bool gameover = false;

	// Use this for initialization
	void Awake () {
		Application.LoadLevelAdditive (Scenes.Scene_HUD);
	}
	void Start(){
			timer = timerDefault;
	}
	// Update is called once per frame
	void Update () {
		if (!gameover) {
			timer -= Time.deltaTime;
			if(onTimerValueChange != null){
				onTimerValueChange(timer);
			}
		}
	}
	void EarlyUpdate(){
		if (timer <= 0) {
			gameover = true;
		}
	}
}
