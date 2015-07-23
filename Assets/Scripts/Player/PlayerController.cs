using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

	public static event System.Action<float> onPlayerHealthChange;
	public static event System.Action<float> onPlayerEnergyChange;


	public GameController ground;
	private static List<InControl.InputDevice> activeDevices = new List<InControl.InputDevice>();
	public InControl.InputDevice inputDevice { get; private set; }
	public bool hasInputDevice { get { return inputDevice != null; } }
	public float minClampY, maxClampY;
	private CharacterController2D character;
	private float mapHeight = 50;
	private float timeWithoutHitDef = 3;
	private float timeWithoutHit;
	private float timeWithoutEnergyDef = 3;
	private float timeWithoutEnergy;

	public AnimationCurve healthRecoverCurve;
	public float maxTimeToRecover = 5;
	public AnimationCurve energyCurve;
	private float recoveryTimerEnergy;
	private float recoveryTimer;

	private float timeToTake = 5;
	private bool energyChanging;
	private float energyValueChangingTo;

	private float health = 100; //Percentage, //Can be changed if you want
	private float maxHealth = 100; //Whatever the max health is. If you dont want to use percentage change

	public float energy = 100; //Percentage, //Can be changed if you want
	private float maxEnergy = 100; //Whatever the max health is. If you dont want to use percentage change



	// Use this for initialization
	void Start () {
		//Start with maximum health
		health = maxHealth;
		//Start with max energy
		energy = maxEnergy;
		energyValueChangingTo = energy;
		character = this.gameObject.GetComponent<CharacterController2D> ();
		BoxCollider2D box = GetComponent<BoxCollider2D> ();

		minClampY = -3.69f;
		maxClampY = (minClampY + mapHeight);
	}
	
	//  is called once per frame
	void Update () {
		if (inputDevice == null) {
			ScanForInputDevice ();
		}
		if (timeWithoutHit < 0) {
			recoverHealth();
		} else {
			timeWithoutHit -= Time.deltaTime;
		}
		if (timeWithoutEnergy < 0) {
			recoverEnergy();
		} else {
			timeWithoutEnergy -= Time.deltaTime;
		}
		if (energyChanging) {
			energy = Mathf.Lerp (energy, energyValueChangingTo, timeToTake * Time.deltaTime);
			if(energy == energyValueChangingTo){
				energyChanging = false;
			}
			if (onPlayerEnergyChange != null) {
				onPlayerEnergyChange (energy / maxEnergy);
			}
		}
		if (health <= 0) {
			ground.gameover = true;
		}

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
		gameObj.BroadcastMessage ("PlayerHit", SendMessageOptions.DontRequireReceiver);
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
	void recoverEnergy(){
		//Adds time to the recover time so that the health will increase quicker
		recoveryTimerEnergy += Time.deltaTime;
		//Adds energy
		if (energy < maxEnergy) {
			energy += (energyRecoveryCurveNormal * maxEnergy);
			energyValueChangingTo = energy;
			//Energy is false
			energyChanging = false;
		}
		if (onPlayerEnergyChange != null) {
			onPlayerEnergyChange(energy / maxEnergy);
		}
	}

	void recoverHealth(){
		//Adds time to the recover time so that the health will increase quicker.
		recoveryTimer += Time.deltaTime;
		//If the health is less then the max then continue to recover.
		if (health < maxHealth) {
			playerHealed (healthRecoveryCurveNormal * maxHealth);
		}
	}
	public void changePowerResource(float value){
		timeWithoutEnergy = timeWithoutEnergyDef;
		recoveryTimerEnergy = 0;
		energyChanging = true;
		energyValueChangingTo -= value;
	}
	float energyRecoveryCurveNormal 
	{
		get {
			return energyCurve.Evaluate(Mathf.Clamp01(recoveryTimerEnergy / timeToTake));
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
