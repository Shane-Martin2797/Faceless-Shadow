using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour {

	private GravityKnuckles gravityKnuckles;


	public virtual void OnTriggerEnter2D(Collider2D collider){
		notifyTarget (collider.gameObject);
	}
	
	public virtual void OnCollisionEnter2D(Collision2D collision){
		notifyTarget (collision.gameObject);
	}

	public virtual void LateUpdate(){
		if (gravityKnuckles == null) {
			gravityKnuckles = FindObjectOfType<GravityKnuckles> ();
		} else {
			float distance = Vector3.Distance(transform.position, gravityKnuckles.transform.position);
			if(distance < gravityKnuckles.maxDistance && !gravityKnuckles.forceList.Contains(this.gameObject)){
				gravityKnuckles.forceList.Add (this.gameObject);
			} else if (distance > gravityKnuckles.maxDistance && gravityKnuckles.forceList.Contains(this.gameObject)) {
				gravityKnuckles.forceList.Remove(this.gameObject);
			}
		}

	}


	public abstract void notifyTarget(GameObject gameObject);
	public abstract void Attack();
	public abstract void CleanUpObject ();
	public abstract void PlayerHit();

}
