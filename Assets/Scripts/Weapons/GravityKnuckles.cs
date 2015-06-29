using UnityEngine;
using System.Collections;

public class GravityKnuckles : BaseWeapon {
	private float cooldown = 3;
	private float gravityBoost = 6;

	// Update is called once per frame
	void Update () {
		if (cooldown >= 0)
			cooldown -= Time.deltaTime;
	}
	void FixedUpdate(){
	}

	public override void Attack ()
	{
		//Grabs the Right Stick (Up, Down, Left, Right) values.
		float inputY = InControl.InputManager.ActiveDevice.RightStickY.Value;
		float inputX = InControl.InputManager.ActiveDevice.RightStickX.Value;

		//Puts these values into a Vector3 called force
		Vector3 force = new Vector3(inputX, inputY, 0) * -gravityBoost;

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
