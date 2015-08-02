using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndGameController : MonoBehaviour {

	public StringHolder stringHolder;
	public static float score;
	public GameObject newHighScore;
	public Text newHighScoreText;
	public Text highscore1;
	public Text highscore2;
	public Text highscore3;
	public Text Score;

	public static void setScore(float value){
		score = value * 750;
	}
	public void updateValues(){
		string name = stringHolder.getString ();
		ScoreHolderScript.SetHighScores (name, score);
	}
	public void refresh(){
		highscore1.text = "1. " + PlayerPrefs.GetString ("HighScore1Name") + " - " + PlayerPrefs.GetFloat ("HighScore1").ToString ("0.0");
		highscore2.text = "2. " + PlayerPrefs.GetString ("HighScore2Name") + " - " + PlayerPrefs.GetFloat ("HighScore2").ToString ("0.0");
		highscore3.text = "3. " + PlayerPrefs.GetString ("HighScore3Name") + " - " + PlayerPrefs.GetFloat ("HighScore3").ToString ("0.0");
	}
	void Update(){
		//if (ScoreHolderScript.checkHighScore (score) && !newHighScoreText.isActiveAndEnabled) {
		//	newHighScore.SetActive (true);
		//} else if(!ScoreHolderScript.checkHighScore(score) && newHighScoreText.isActiveAndEnabled){
		//	newHighScore.SetActive(false);
		//}
		//if (!Screen.showCursor || Screen.lockCursor) {
		//	Screen.showCursor = true;
		//	Screen.lockCursor = false;
		//}
	}
	void Start(){
		Score.text = score.ToString ("Score: 0");
	}
}
