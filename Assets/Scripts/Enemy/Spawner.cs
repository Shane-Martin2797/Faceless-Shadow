using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {


	public float spawnCount = 20;

	void Spawn(GameObject gameObj){
		for (int i = 0; i < spawnCount; i++) {
			Vector3 random = Vector3.zero;
			random.z = Random.value * 360;
			GameObject GameObj = Instantiate(gameObj, this.gameObject.transform.position, this.gameObject.transform.rotation) as GameObject;
			GameObj.transform.localEulerAngles = random;
		}
	}
}
