using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {

	public PlayerController target;
	private Vector3 originalPosition;
	private float maxHeight = 100;
	private float time = 0;

	// Use this for initialization
	void Start () {
		originalPosition = transform.position;
		target = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 cameraPosition = target.transform.position;
		cameraPosition.z = transform.position.z;
		cameraPosition.y = Mathf.Clamp(cameraPosition.y,0,maxHeight);
		if (transform.position != cameraPosition) {
			time += Time.deltaTime;
			transform.position = Vector3.Lerp (transform.position, cameraPosition, time * Time.deltaTime);
		} else {
			time = 0;
		}
	}
}
