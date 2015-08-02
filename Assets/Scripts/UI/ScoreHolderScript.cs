using UnityEngine;
using System.Collections;

public class ScoreHolderScript {

	public static int totalstored = 3;

	public static bool checkHighScore(float score){
		if(score >= PlayerPrefs.GetFloat("HighScore3")){
			return true;
		}
		return false;
	}

	public static void SetHighScores(string name1, float score1){
		if(score1 > PlayerPrefs.GetFloat("HighScore1")){
			string name2 = PlayerPrefs.GetString("HighScore1Name");
			float score2 = PlayerPrefs.GetFloat("HighScore1");
			PlayerPrefs.SetString("HighScore2Name", name2);
			PlayerPrefs.SetFloat("HighScore2", score2);
			string name3 = PlayerPrefs.GetString("HighScore2Name");
			float score3 = PlayerPrefs.GetFloat("HighScore2");
			PlayerPrefs.SetString("HighScore3Name", name3);
			PlayerPrefs.SetFloat("HighScore3", score3);

			PlayerPrefs.SetString("HighScore1Name", name1);
			PlayerPrefs.SetFloat("HighScore1", score1);
		}
		else if(score1 > PlayerPrefs.GetFloat("HighScore2")){
			string name = PlayerPrefs.GetString("HighScore2Name");
			float score = PlayerPrefs.GetFloat("HighScore2");
			PlayerPrefs.SetString("HighScore3Name", name);
			PlayerPrefs.SetFloat("HighScore3", score);
			PlayerPrefs.SetString("HighScore2Name", name1);
			PlayerPrefs.SetFloat("HighScore2", score1);
		}
		else if(score1 > PlayerPrefs.GetFloat("HighScore3")){
			PlayerPrefs.SetString("HighScore3Name", name1);
			PlayerPrefs.SetFloat("HighScore3", score1);
		}
	}

	public static void refreshScores(){
		PlayerPrefs.SetString("HighScore1Name", "AAA");
		PlayerPrefs.SetFloat("HighScore1", 0);
		PlayerPrefs.SetString("HighScore2Name", "AAA");
		PlayerPrefs.SetFloat("HighScore2", 0);
		PlayerPrefs.SetString("HighScore3Name", "AAA");
		PlayerPrefs.SetFloat("HighScore3", 0);
	}
	public static string getName(int value){
		return PlayerPrefs.GetString ("HighScore" + value + "Name");
	}
	public static float getScore(int value){
		return PlayerPrefs.GetFloat ("HighScore" + value);
	}
}
