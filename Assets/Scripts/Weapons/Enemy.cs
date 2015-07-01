using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour {

	private GravityKnuckles gravityKnuckles;

	public virtual void Awake(){
		gravityKnuckles = FindObjectOfType<GravityKnuckles>();
	}


	public virtual void OnTriggerEnter2D(Collider2D collider){
		notifyTarget (collider.gameObject);
	}
	
	public virtual void OnCollisionEnter2D(Collision2D collision){
		notifyTarget (collision.gameObject);
	}

	public abstract void notifyTarget(GameObject gameObject);
	public abstract void Attack();
	public abstract void PlayerHit();

	public virtual void CleanUpObject ()
	{
		gravityKnuckles.forceList.Remove (gameObject);
		Destroy (gameObject);
	}


}
