using UnityEngine;
using System.Collections;

public class TurretController : MonoBehaviour {
	public GameObject player;
	public Vector3 playerPos;
	public float timeTillFire;
	public float timeResetAmount;
	public Rigidbody2D Bullet;
	public float bulletSpeed;
	void awake () {

	}
	// Use this for initialization
	void Start () {
		//playerPos = player.transform.localPosition;
		timeTillFire = timeResetAmount;
	}
	
	// Update is called once per frame
	void Update () 
	{
		timeTillFire -= Time.deltaTime;
		if (timeTillFire <= 0)
		{
			timeTillFire = timeResetAmount;
			FireBullet();
		}

		playerPos = player.transform.position;
		LookAtPlayer();


		//this.transform.LookAt(playerPos);
		//this.transform.Rotate(new Vector3(0,-90,0),Space.Self);
	}

	void LookAtPlayer()
	{
		this.transform.LookAt (playerPos); //follows the player 
		this.transform.Rotate(new Vector3(0,-90,270),Space.Self); //rotates the turret so u can see it
	}

	void FireBullet()
	{
		Rigidbody2D bulletInstantiate;
		bulletInstantiate = Instantiate (Bullet, this.transform.localPosition, this.transform.localRotation)as Rigidbody2D;
		bulletInstantiate.rigidbody2D.AddForce (transform.up * bulletSpeed);
	}
}
