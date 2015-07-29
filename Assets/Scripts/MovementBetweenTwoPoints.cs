using UnityEngine;
using System.Collections;

public class MovementBetweenTwoPoints : MonoBehaviour {

	private CharacterController2D player;
	public GameObject pointA;
	public GameObject pointB;
	public float distanceAccuracy;
	private Vector3 targetPosition;
	private Vector3 movement;
	public float speed = 2;
	public bool lerps;
	public bool playerMovesWith;
	private bool playerIsTouching;
	private BoxCollider2D box;
	private float maxHeightAbove = 5;
	private Vector3 offset = Vector3.zero;

	// Use this for initialization
	void Start () {
		targetPosition = pointA.transform.position;
		player = FindObjectOfType<CharacterController2D> ();
		box = this.gameObject.GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.isGrounded) {
			Vector3 playerPos = player.transform.position;
			Vector3 thisPos = transform.position;
			if (playerPos.y > thisPos.y && playerPos.y <= thisPos.y + maxHeightAbove) {
				if(playerPos.x < thisPos.x + ((transform.localScale.x * box.size.x) / 2) && playerPos.x > thisPos.x - ((transform.localScale.x * box.size.x) / 2)){
					playerIsTouching = true;
					offset = player.transform.position - gameObject.transform.position;
				} else {
					playerIsTouching = false;
				}
			} else {
				playerIsTouching = false;
			}
		}

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
			if(playerMovesWith){
				if(playerIsTouching){
					if(player.isGrounded){
						Vector3 pos = player.transform.position;
						pos = transform.position + offset;
						player.transform.position = pos;
					}
				}
			}
		}
	}
}
