using UnityEngine;
using System.Collections;

public class GravityKnuckles : BaseWeapon {
	private float cooldown = 3;
	private float gravityBoost = 6;
	public GravCircle gravCircle;
	private bool lerping = false;
	private Vector3 endPos;

	// Update is called once per frame
	void Update () {
		if (cooldown >= 0)
			cooldown -= Time.deltaTime;
	}
	void FixedUpdate(){
		if (lerping) {
			movePlayer();
		}
	}

	void movePlayer(){

		player.transform.position = Vector3.Lerp (player.transform.position, endPos, 10 * Time.deltaTime);
		Debug.Log ("Lerping");
	}
	void GravCircleHit(){
		lerping = false;
	}
	public override void Attack ()
	{
		//Grabs the Right Stick (Up, Down, Left, Right) values.
		float inputY = InControl.InputManager.ActiveDevice.RightStickY.Value;
		float inputX = InControl.InputManager.ActiveDevice.RightStickX.Value;

		//Puts these values into a Vector2 called force
		Vector3 force = new Vector3(inputX, inputY, 0) * -gravityBoost;

		//Update where the end position is
		endPos = (force + player.transform.position);
		gravCircle.transform.position = (endPos);
		lerping = true;
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
