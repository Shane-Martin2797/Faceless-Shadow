using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerCombat : MonoBehaviour {

    /// <summary>
    /// Get the currently selected weapon
    /// </summary>
    public BaseWeapon currentWeapon
    {
        get
        {
            if (weapons.Count > 0)
            {
                return weapons[currentWeaponIndex];
            }
            else
            {
                return null;
            }
        }
    }

    /// <summary>
    /// The index of the currently selected weapon
    /// </summary>
    private int currentWeaponIndex = 0;

    /// <summary>
    /// A list of weapons available to the player
    /// </summary>
    public List<BaseWeapon> weapons = new List<BaseWeapon>();

	// Use this for initialization
	void Start () {
        //Make sure we have the active weapon enabled on start
        foreach (BaseWeapon weapon in weapons)
        {
            weapon.gameObject.SetActive(false);
        }

        if (currentWeapon != null)
        {
            currentWeapon.gameObject.SetActive(true);
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (currentWeapon != null && currentWeapon.isReady)
        { //if we have a weapon selected, and that weapon is not attacking
            if (InControl.InputManager.ActiveDevice.Action2.IsPressed)
            { //trigger the current weapon to attack
                currentWeapon.Attack();
            } else if (InControl.InputManager.ActiveDevice.Action2.WasReleased){
				currentWeapon.SecondaryAttack();
			}
        }
		if(InControl.InputManager.ActiveDevice.Action4.WasPressed){
			currentWeapon.gameObject.SetActive(false);
			currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Count;
			currentWeapon.gameObject.SetActive(true);
		}
	}
}
