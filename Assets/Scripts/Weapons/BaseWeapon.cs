using UnityEngine;
using System.Collections;

public abstract class BaseWeapon : MonoBehaviour {
	public PlayerController player;
	public PlayerMovement playerMovement;
	public CharacterController2D characterController2D;
	public virtual void Awake(){
		player = FindObjectOfType<PlayerController> ();
		playerMovement = FindObjectOfType<PlayerMovement> ();
		characterController2D = FindObjectOfType<CharacterController2D> ();
	}
    /// <summary>
    /// Return true if the weapon is ready to fire
    /// </summary>
    public abstract bool isReady { get; }

    /// <summary>
    /// Tell the weapon to perform it's attack
    /// </summary>
    public abstract void Attack();
}
