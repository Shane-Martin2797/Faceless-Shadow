using UnityEngine;
using System.Collections;

public class ShredderMine : Enemy {

	public float spikesToSpawn = 20;
	public float delay = 1;
	public GameObject spike;
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
		for (int i = 0; i < spikesToSpawn; i++) {
			Vector3 random = Vector3.zero;
			random.z = Random.value * 360;
			GameObject spikes = Instantiate(spike, this.gameObject.transform.position, this.gameObject.transform.rotation) as GameObject;
			spikes.transform.localEulerAngles = random;
		}
		CleanUpObject ();
	}
}
