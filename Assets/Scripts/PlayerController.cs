using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private float health = 100; //Percentage, //Can be changed if you want
	private float maxHealth = 100; //Whatever the max health is. If you dont want to use percentage change



	// Use this for initialization
	void Start () {
		//Start with maximum health
		health = maxHealth;
	
	}
	
	// Update is called once per frame
	void Update () {

	}



	//Movement Stuff
	void FixedUpdate(){
		//If Input is != 0 run playermovement;
		player_Movement ();
	}

	//All player movement is done in here, including looking
	void player_Movement(){
		//Store Input in a vectore

		//Look around

		//Move Player
	}

	//Code for player jump (Includes double), triple should be included in gravity knuckles.
	void Jump(){

	}




	//Health stuff
	void playerDamaged(float damage){
		//Damage the player
		health -= damage;
		//If the players health drops below zero make it zero
		if (health < 0)
			health = 0;
	}
	void playerHealed(float healAmount){
		//heal the player by the amount
		health += healAmount;
		//If the players health is over max, set it to max.
		if (health > maxHealth)
			health = maxHealth;

	}

}
