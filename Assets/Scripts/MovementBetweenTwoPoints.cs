using UnityEngine;
using System.Collections;

public class MovementBetweenTwoPoints : MonoBehaviour {

	public GameObject pointA;
	public GameObject pointB;
	public float distanceAccuracy;
	private Vector3 targetPosition;
	private Vector3 movement;
	public float speed = 2;
	public bool lerps;

	// Use this for initialization
	void Start () {
		targetPosition = pointA.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (targetPosition != null) {
			if (Vector3.Distance (transform.position, pointA.transform.position) <= distanceAccuracy) {
				targetPosition = pointB.transform.position;
			}
			if (Vector3.Distance (transform.position, pointB.transform.position) <= distanceAccuracy) {
				targetPosition = pointA.transform.position;
			}
			if(lerps){
				transform.position = Vector3.Lerp(transform.position, targetPosition, .25f * speed * Time.deltaTime);
			} else {
				Vector3 movement = -(transform.position - targetPosition).normalized;
				transform.Translate(movement * speed * Time.deltaTime);
			}
		}
	}
}
