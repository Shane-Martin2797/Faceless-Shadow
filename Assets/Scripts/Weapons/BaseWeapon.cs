using UnityEngine;
using System.Collections;

public abstract class BaseWeapon : MonoBehaviour {
	public PlayerController player;

	public virtual void Awake(){
		player = FindObjectOfType<PlayerController> ();
	}

    /// <summary>
    /// Return true if the weapon is ready to fire
    /// </summary>
    public abstract bool isReady { get; }

    /// <summary>
    /// Tell the weapon to perform it's attack
    /// </summary>
    public abstract void Attack();

	public abstract void SecondaryAttack();
}
