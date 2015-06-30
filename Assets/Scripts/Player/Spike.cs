using UnityEngine;
using System.Collections;

public class Spike : Enemy {

	private float minDamage = 20; 			//Percentage of Health
	private float maxDamage = 40; 			//Percentage of Health
	private float lifetime = 5;
	private float Lifetime;
	public GameObject target;
	private Vector3 targetPosition;

	void Start(){
		targetPosition = (transform.position + transform.up * 10);
		Lifetime = lifetime;
	}
	void Update(){
		Lifetime -= Time.deltaTime;
		if (Lifetime <= 0) {
			CleanUpObject();
		}
	}


	public override void PlayerHit ()
	{
		target = FindObjectOfType<PlayerController> ().gameObject;
		Attack ();
	}


	public override void notifyTarget (GameObject gameObject)
	{
		if (gameObject.tag != "Projectile" && gameObject.tag != "Weapon") {
			target = gameObject;
			Attack ();
			Debug.Log (gameObject);
		}
	}

	public override void Attack ()
	{
		DamageInfo damageInfo = new DamageInfo ();
		damageInfo.damage = Random.Range (minDamage, maxDamage + 1);
		target.SendMessage ("DamageHit", damageInfo, SendMessageOptions.DontRequireReceiver);
		CleanUpObject ();

	}

	public override void CleanUpObject(){
		Destroy (this.gameObject);
	}

	void FixedUpdate(){
		transform.position = Vector3.Lerp(transform.position, targetPosition, 1 * Time.deltaTime);
	}

}
