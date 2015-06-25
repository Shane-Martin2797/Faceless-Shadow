using UnityEngine;
using System.Collections;

public class GravCircle : MonoBehaviour {
	public GravityKnuckles gravityKnuckles;
	public PlayerController player;

	// Use this for initialization
	void Start () {
		gravityKnuckles = FindObjectOfType<GravityKnuckles> ();
		player = FindObjectOfType<PlayerController> ();
	}

	void OnCollisionEnter2D(Collision2D collision){
		notifyHit (collision.gameObject);
	}
	void OnTriggerEnter2D(Collider2D collider){
		notifyHit (collider.gameObject);
	}
	void notifyHit(GameObject gameObject){
		gameObject.SendMessage ("GravCircleHit", SendMessageOptions.DontRequireReceiver);
	}
	
}
