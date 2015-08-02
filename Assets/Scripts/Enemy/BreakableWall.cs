using UnityEngine;
using System.Collections;

public class BreakableWall : MonoBehaviour {

	void GravityKnucklesAffect(float rotation){
		CleanUpObject ();
	}

	void CleanUpObject(){
		Destroy (this.gameObject);
	}
}
