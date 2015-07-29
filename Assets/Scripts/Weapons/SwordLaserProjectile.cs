using UnityEngine;
using System.Collections;

public class SwordLaserProjectile : MonoBehaviour {

	private float weaponDamage;
	public float speed = 10;
	private float count;
	private float countMax = 3;
	public float lifetime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * Time.deltaTime * speed);
		lifetime -= Time.deltaTime;
		if (lifetime <= 0) {
			CleanUpObject (this.gameObject);
		}
	}

	void SetDamage(DamageInfo damage){
		weaponDamage = damage.damage;
	}

	void OnCollisionEnter2D(Collision2D collision){
		CleanUpObject (collision.gameObject);
	}
	void OnTriggerEnter2D(Collider2D collider){
		CleanUpObject (collider.gameObject);
	}
	void CleanUpObject(GameObject gameObj){
		if (gameObject.tag != "Player" && gameObj.tag != "Projectile") {
			count++;
		}
		if(count >= countMax || gameObj.tag == "Level" || lifetime <= 0){
		Destroy (this.gameObject);
		}
	}
}
