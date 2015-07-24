using UnityEngine;
using System.Collections;

public class Moyashimasu : BaseWeapon {

	public float powerToRemove = 0;
	private float cooldown;
	private float count;
	private float powerCounter;
	public float holdMin = 3;
	private bool charged;
	public SwordLaserProjectile swordProj;
	private float maxCharge = 3;
	private float minDamage;
	private float maxDamage = 10;
	private float powerMax = 100;

	void Update(){
	}

	public override void Attack ()
	{
		count += Time.deltaTime;
		if (count >= holdMin) {
			powerCounter += Time.deltaTime;
			if(!charged){
			charged = true;
			}
		}
	}


	public override void SecondaryAttack ()
	{
		if (charged) {
			powerToRemove = (powerCounter / maxCharge) * powerMax;
			SwordLaserProjectile laser = Instantiate (swordProj, this.transform.position, this.transform.rotation) as SwordLaserProjectile;
			DamageInfo damage = new DamageInfo ();
			damage.damage = GetDamage ();
			laser.BroadcastMessage ("SetDamage", damage, SendMessageOptions.DontRequireReceiver);
			player.changePowerResource (powerToRemove);
		} else {
			// Do a slash attack
		}

		powerToRemove = 0;
		count = 0;
		powerCounter = 0;
	}

	float GetDamage(){
		float returnValueDamage;
		if (powerCounter >= 3) {
			returnValueDamage = maxDamage;
		} else {
			returnValueDamage = (powerCounter / maxCharge) * maxDamage;
		}
		return returnValueDamage;
	}


	public override bool isReady {
		get {
			return (cooldown <= 0 && player.energy >= powerToRemove);
		}
	}
}
