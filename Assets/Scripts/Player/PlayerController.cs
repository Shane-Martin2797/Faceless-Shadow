using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

	private static List<InControl.InputDevice> activeDevices = new List<InControl.InputDevice>();
	public InControl.InputDevice inputDevice { get; private set; }
	public bool hasInputDevice { get { return inputDevice != null; } }


	private float health = 100; //Percentage, //Can be changed if you want
	private float maxHealth = 100; //Whatever the max health is. If you dont want to use percentage change



	// Use this for initialization
	void Start () {
		//Start with maximum health
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (inputDevice == null) {
			ScanForInputDevice ();
		}

	}

	void FixedUpdate(){
	}


	void OnTriggerEnter2D(Collider2D collider){
		notifyGameObject (collider.gameObject);
	}
	void OnCollisionEnter2D(Collision2D collision){
		notifyGameObject (collision.gameObject);
	}

	void notifyGameObject(GameObject gameObj){
		gameObj.BroadcastMessage ("PlayerHit");
	}
	//Health stuff
	void playerDamaged(float damage){
		//Damage the player
		health -= damage;
		//If the players health drops below zero make it zero
		if (health < 0)
			health = 0;
	}
	void playerHealed(float healAmount){
		//heal the player by the amount
		health += healAmount;
		//If the players health is over max, set it to max.
		if (health > maxHealth)
			health = maxHealth;

	}

	void ReleaseActiveInputDevice()
	{
		if (inputDevice != null && activeDevices.Contains(inputDevice))
		{
			activeDevices.Remove(inputDevice);
		}
	}
	
	private void ScanForInputDevice()
	{
		foreach (var device in InControl.InputManager.Devices)
		{
			if (!activeDevices.Contains(device))
			{
				activeDevices.Add(device);
				inputDevice = device;
				return;
			}
		}
	}
}
