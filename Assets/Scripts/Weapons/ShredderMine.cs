using UnityEngine;
using System.Collections;

public class ShredderMine : Enemy {

	public float spikesToSpawn;
	public GameObject spike;

	public override void notifyTarget (GameObject gameObject)
	{
		Attack ();
	}

	void Attack(){
		for (int i = 0; i < spikesToSpawn; i++) {
			Vector3 random = Random.insideUnitSphere;
			random.z = 0;
			GameObject spikes = Instantiate(spike, this.gameObject.transform.position, this.gameObject.transform.rotation) as GameObject;
			spikes.transform.localEulerAngles = random;
		}
	}
}
