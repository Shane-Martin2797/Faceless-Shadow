using UnityEngine;
using System.Collections;

public class ShredderMine : Enemy {

	public float spikesToSpawn;
	public GameObject spike;

	public override void notifyTarget (GameObject gameObject)
	{
		if(gameObject.tag == "Player")
		Attack ();
	}
	public override void PlayerHit(){
		Attack ();
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


	public override void CleanUpObject ()
	{
		Destroy (gameObject);
	}

}
