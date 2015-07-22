using UnityEngine;
using System.Collections;

public class ShredderMine : Enemy {

	public float spikesToSpawn = 20;
	public float delay = 0;
	public GameObject spike;
	public Spawner spawner;
	private bool attacking = false;

	public override void notifyTarget (GameObject gameObject)
	{
		if(gameObject.tag == "Player")
		PlayerHit ();
	}
	public override void PlayerHit(){
		attacking = true;
	}

	void Update(){

		if (attacking) {
			if(delay <= 0){
				Attack ();
			} else {
				delay -= Time.deltaTime;
			}
		}
	}

	public override void Attack(){
		spawner.spawnCount = spikesToSpawn;
		spawner.BroadcastMessage ("Spawn", spike, SendMessageOptions.DontRequireReceiver);
		CleanUpObject ();
	}
}
