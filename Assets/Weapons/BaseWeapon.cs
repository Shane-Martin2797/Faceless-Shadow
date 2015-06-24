using UnityEngine;
using System.Collections;

public abstract class BaseWeapon : MonoBehaviour {

    /// <summary>
    /// Return true if the weapon is ready to fire
    /// </summary>
    public abstract bool isReady { get; }

    /// <summary>
    /// Tell the weapon to perform it's attack
    /// </summary>
    public abstract void Attack();
}
