using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {

	public PlayerController target;

	// Use this for initialization
	void Start () {
		target = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 cameraPosition = transform.position;
		cameraPosition.x = target.transform.position.x;
		if (transform.position != cameraPosition) {
			transform.position = Vector3.Lerp (transform.position, cameraPosition, 3 * Time.deltaTime);
		}
	}
}
