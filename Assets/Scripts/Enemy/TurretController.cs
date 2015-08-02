using UnityEngine;
using System.Collections;

public class TurretController : MonoBehaviour {
	public PlayerController player;
	public GameObject barrel;
	public Vector3 playerPos;
	private float timeTillFire;
	public float timeResetAmount;
	public Spike Bullet;
	public float bulletSpeed;
	public int burstAmount = 10;
	private int currentFired;
	public float cooldown = 3;
	private float cool;
	private float timeSinceLastFire;

	// Use this for initialization
	void Start () {
		timeTillFire = timeResetAmount;
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (currentFired < burstAmount) {
			timeTillFire -= Time.deltaTime;
			if(canSeePlayer()){
			if (timeTillFire <= 0) {
				timeTillFire = timeResetAmount;
				FireBullet ();
				currentFired++;
				timeSinceLastFire = 0;
			}
			}
		} else {
			cool -= Time.deltaTime;
		}
		if (cool <= 0) {
			currentFired = 0;
			cool = cooldown;
		}
		if (timeSinceLastFire >= 10) {
			currentFired = 0;
		} else {
			timeSinceLastFire += Time.deltaTime;
		}

		playerPos = player.transform.position;
		LookAtPlayer();
	}

	bool canSeePlayer(){
		Physics2D.raycastsHitTriggers = false;
		RaycastHit2D hit = Physics2D.Raycast (transform.position, transform.up);
		if(hit.collider != null){
			if(hit.collider.gameObject == player.gameObject){
				return true;
			}
		}
		return false;
	}
		void LookAtPlayer()
	{
		Vector3 angle = (player.transform.position - gameObject.transform.position).normalized;
		float angleValue = Mathf.Atan2 (angle.y,angle.x)*Mathf.Rad2Deg-90;
		transform.localEulerAngles = new Vector3 (0, 0, angleValue);



		//Old way of doing the rotation, was checking if I could create a slow follow but it wouldnt work
	//	this.transform.LookAt (playerPos); //follows the player 
	//	this.transform.Rotate(new Vector3(0,-90,270),Space.Self); //rotates the turret so u can see it
	}

	void FireBullet()
	{
		Spike bulletInstantiate = Instantiate (Bullet, barrel.transform.position, this.transform.localRotation) as Spike;
		bulletInstantiate.speed = bulletSpeed;
	}
}
