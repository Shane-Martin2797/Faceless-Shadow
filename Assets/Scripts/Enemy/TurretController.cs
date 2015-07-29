using UnityEngine;
using System.Collections;

public class TurretController : MonoBehaviour {
	public PlayerController player;
	public Vector3 playerPos;
	private float timeTillFire;
	public float timeResetAmount;
	public Spike Bullet;
	public float bulletSpeed;

	// Use this for initialization
	void Start () {
		timeTillFire = timeResetAmount;
		player = FindObjectOfType<PlayerController> ();
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
	}

	void LookAtPlayer()
	{
		this.transform.LookAt (playerPos); //follows the player 
		this.transform.Rotate(new Vector3(0,-90,270),Space.Self); //rotates the turret so u can see it
	}

	void FireBullet()
	{
		Spike bulletInstantiate = Instantiate (Bullet, this.transform.localPosition, this.transform.localRotation) as Spike;
		bulletInstantiate.speed = bulletSpeed;
		//bulletInstantiate.rigidbody2D.AddForce (transform.up * bulletSpeed);
	}
}
