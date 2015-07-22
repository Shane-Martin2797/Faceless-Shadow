using UnityEngine;
using System.Collections;

public class Moyashimasu : BaseWeapon {

	public float powerToRemove = 0;
	private float cooldown;
	private float count;
	private float powerCounter;
	public float holdMin = 3;
	private bool charged;

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

		}
	}


	public override bool isReady {
		get {
			return (cooldown <= 0 && player.energy >= powerToRemove);
		}
	}
}
