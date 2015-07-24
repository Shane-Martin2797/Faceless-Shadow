using UnityEngine;
using System.Collections;

public class SwordLaserProjectile : MonoBehaviour {

	private float weaponDamage;
	public float speed = 10;
	private float count;
	private float countMax = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * Time.deltaTime * speed);
	}

	void SetDamage(DamageInfo damage){
		weaponDamage = damage.damage;
	}

	void OnCollisionEnter2D(Collision2D collision){
		Debug.Log (collision.gameObject);
		CleanUpObject (collision.gameObject);
	}
	void CleanUpObject(GameObject gameObj){
		if (gameObject.tag != "Player" && gameObj.tag != "Projectile") {
			count++;
		}
		if(count >= countMax || gameObj.tag == "Level"){
		Destroy (this.gameObject);
		}
	}
}
