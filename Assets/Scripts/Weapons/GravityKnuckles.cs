﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GravityKnuckles : BaseWeapon {


	private float cooldown = 3;
	private float gravityBoost = 800;
	public float maxDistance = 5;
	public float powerToRemove = 100;
	private CircleCollider2D circle;
	private CharacterController2D controller;


	public List<GameObject> forceList;

	void Start(){
		player = FindObjectOfType<PlayerController> ();
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
			if(gObject != null){
				if(gObject.rigidbody2D != null){
					Vector3 angle = (gObject.transform.position - this.gameObject.transform.position).normalized;
					float angleValue = Mathf.Atan2 (angle.y,angle.x)*Mathf.Rad2Deg-90;
					float distance = Vector3.Distance(this.gameObject.transform.position, gObject.transform.position);
					if(gObject.tag == "Projectile"){
					gObject.rigidbody2D.AddForce(angle * (1/distance) * maxDistance * gravityBoost);
					}
					gObject.BroadcastMessage("GravityKnucklesAffect", (angleValue), SendMessageOptions.DontRequireReceiver);
			}
			}
		}

		//Remove Power from resource
		player.changePowerResource (powerToRemove);
		cooldown = 3;
	}

	void OnTriggerEnter2D(Collider2D collider){
		AddToList (collider.gameObject);
	}

	void OnCollisionEnter2D(Collision2D collision){
		AddToList (collision.gameObject);
	}

	void OnTriggerExit2D(Collider2D collider){
		if (!collider.isTrigger) {
			RemoveFromList (collider.gameObject);
		}
	}
	
	void OnCollisionExit2D(Collision2D collision){
		if (!collider.isTrigger) {
			RemoveFromList (collider.gameObject);
		}
	}

	void AddToList(GameObject gameObj){
		forceList.Add (gameObj);
	}
	public void RemoveFromList(GameObject gameObj){
		forceList.Remove (gameObj);
	}
	public override bool isReady {
		get {
			return (cooldown <= 0 && !controller.isGrounded && player.energy >= powerToRemove);
		}
	}
	public override void SecondaryAttack ()
	{
		//This doesnt need a secondary attack
	}
	
	void OnDisable ()
	{
		for (int i = (forceList.Count - 1); i >= 0; i--) {
			RemoveFromList(forceList[i]);
		}
	}
}
