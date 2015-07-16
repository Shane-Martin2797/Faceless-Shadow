using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

	public static event System.Action<float> onPlayerHealthChange;


	public GameController ground;
	private static List<InControl.InputDevice> activeDevices = new List<InControl.InputDevice>();
	public InControl.InputDevice inputDevice { get; private set; }
	public bool hasInputDevice { get { return inputDevice != null; } }
	public float minClampY, maxClampY;
	private CharacterController2D character;
	private float mapHeight = 50;
	private float timeWithoutHitDef = 3;
	private float timeWithoutHit;
	public AnimationCurve healthRecoverCurve;
	public float maxTimeToRecover = 5;
	private float recoveryTimer;


	private float health = 100; //Percentage, //Can be changed if you want
	private float maxHealth = 100; //Whatever the max health is. If you dont want to use percentage change



	// Use this for initialization
	void Start () {
		//Start with maximum health
		health = maxHealth;
		character = this.gameObject.GetComponent<CharacterController2D> ();
		BoxCollider2D box = GetComponent<BoxCollider2D> ();

		minClampY = -3.69f;
		maxClampY = (minClampY + mapHeight);
	}
	
	// Update is called once per frame
	void Update () {
		if (inputDevice == null) {
			ScanForInputDevice ();
		}
		if (timeWithoutHit < 0) {
			recoverHealth();
		} else {
			timeWithoutHit -= Time.deltaTime;
		}
		/*if (character.isGrounded) {
			minClampY = this.gameObject.transform.position.y;
			maxClampY = (minClampY + mapHeight);
		} else {
			minClampY = -3.69f;
		}*/ // Doesnt work, because as soon as you go through the floor, you are not grounded.
	}

	void FixedUpdate(){
		Vector3 pos = transform.position;
		pos.y = Mathf.Clamp (pos.y, minClampY, maxClampY);
		transform.position = pos;
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
		if (onPlayerHealthChange != null)
			onPlayerHealthChange(health/maxHealth);
		recoveryTimer = 0;
		timeWithoutHit = timeWithoutHitDef;
	}
	void playerHealed(float healAmount){
		//heal the player by the amount
		health += healAmount;
		//If the players health is over max, set it to max.
		if (health > maxHealth)
			health = maxHealth;
		if (onPlayerHealthChange != null)
			onPlayerHealthChange(health/maxHealth);
	}

	void DamageHit(DamageInfo damage){
		playerDamaged (damage.damage);
	}


	void recoverHealth(){
		//Adds time to the recover time so that the health will increase quicker.
		recoveryTimer += Time.deltaTime;
		//If the health is less then the max then continue to recover.
		if (health < maxHealth) {
			playerHealed (healthRecoveryCurveNormal * maxHealth);
		}
	}

	float healthRecoveryCurveNormal 
	{
		get {
			return healthRecoverCurve.Evaluate(Mathf.Clamp01(recoveryTimer / maxTimeToRecover));
		}
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
