using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GravityKnuckles : BaseWeapon {


	private float cooldown = 3;
	private float gravityBoost = 800;
	public float maxDistance = 5;
	private CircleCollider2D circle;
	private CharacterController2D controller;


	public List<GameObject> forceList = new List<GameObject>();

	void Start(){
		circle = GetComponent<CircleCollider2D> ();
		circle.radius = (maxDistance / 2);
		controller = FindObjectOfType<CharacterController2D>().GetComponent<CharacterController2D>();
	}


	// Update is called once per frame
	void Update () {
		if (cooldown >= 0)
			cooldown -= Time.deltaTime;
	}
	
	public override void Attack ()
	{
		//Grabs the Right Stick (Up, Down, Left, Right) values.
		float inputY = InControl.InputManager.ActiveDevice.RightStickY.Value;
		float inputX = InControl.InputManager.ActiveDevice.RightStickX.Value;

		//Puts these values into a Vector3 called force
		Vector3 force = new Vector2(inputX, inputY) * -gravityBoost;
		player.rigidbody2D.AddForce (force);

		foreach (GameObject gObject in forceList) {
			if(gObject.rigidbody2D != null){
				if(gObject != null){
					Vector3 angle = (gObject.transform.position - this.gameObject.transform.position).normalized;
					float angleValue = Mathf.Atan2 (angle.y,angle.x)*Mathf.Rad2Deg-90;
					float distance = Vector3.Distance(this.gameObject.transform.position, gObject.transform.position);
					gObject.rigidbody2D.AddForce(angle * (1/distance) * maxDistance * gravityBoost);
					gObject.BroadcastMessage("GravityKnucklesAffect", (angleValue), SendMessageOptions.DontRequireReceiver);
			}
			}
		}

		//Remove Power from resource
		//player.removePowerResource(25%)
		cooldown = 3;
	}

	void OnTriggerEnter2D(Collider2D collider){
		AddToList (collider.gameObject);
	}

	void OnCollisionEnter2D(Collision2D collision){
		AddToList (collision.gameObject);
	}

	void OnTriggerExit2D(Collider2D collider){
		RemoveFromList (collider.gameObject);
	}
	
	void OnCollisionExit2D(Collision2D collision){
		RemoveFromList (collision.gameObject);
	}

	void AddToList(GameObject gameObj){
		forceList.Add (gameObj);
	}
	void RemoveFromList(GameObject gameObj){
		forceList.Remove (gameObj);
	}
	public override bool isReady {
		get {
			return (cooldown <= 0 && !controller.isGrounded);
		}
	}

}
