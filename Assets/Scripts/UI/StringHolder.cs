using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StringHolder : MonoBehaviour {

	public GameObject holder;
	public GameObject message;
	public EndGameController canvas;
	public InputField name;
	private string strings;

	public void OnClick_Done(){
		strings = name.text;
		canvas.updateValues ();
		canvas.refresh ();
		holder.SetActive (false);
		message.SetActive (true);
	}
	public string getString(){
		return strings;
	}
}
