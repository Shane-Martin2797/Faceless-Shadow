using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour {

	public virtual void OnTriggerEnter(Collider collider){
		notifyTarget (collider.gameObject);
		Debug.Log ("Inside");
	}
	
	public virtual void OnCollisionEnter(Collision collision){
		notifyTarget (collision.gameObject);
		Debug.Log ("Inside");
	}

	public abstract void notifyTarget(GameObject gameObject);

}
