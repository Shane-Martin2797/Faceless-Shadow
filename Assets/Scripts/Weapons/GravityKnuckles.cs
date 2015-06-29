using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GravityKnuckles : BaseWeapon {

	private float cooldown = 3;
	private float gravityBoost = 800;
	public float maxDistance = 5;

	public List<GameObject> forceList = new List<GameObject>();


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
		Debug.Log ("Added: " + force);

		foreach (var gObject in forceList) {
			if(gObject.rigidbody2D != null){
				Vector3 angle = (gObject.transform.position - this.gameObject.transform.position).normalized;
			float distance = Vector3.Distance(this.gameObject.transform.position, gObject.transform.position);
			gObject.rigidbody2D.AddForce(angle * (1/distance) * maxDistance * gravityBoost);
			}
		}

		//Remove Power from resource
		//player.removePowerResource(value)
		cooldown = 3;
	}

	public override bool isReady {
		get {
			return (cooldown <= 0);
		}
	}

}
