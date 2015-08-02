using UnityEngine;
using System.Collections;

public class SweeperController : MonoBehaviour {

	public float moveSpeed;

	public GameObject player;

	public Vector2 playerPos;

	public Vector2 sweeperPos;

	public bool playerHasntJumped = true;

	public bool playerHasJumped = false;

	public float jumpTimer; 

	public float stunTimer;

	public float coolDownTimer;

	public bool playerStunned = false;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		playerPos = player.transform.localPosition;

		sweeperPos = this.transform.localPosition;

	}
	void FixedUpdate()
	{
		transform.position = Vector2.MoveTowards (transform.position, playerPos, moveSpeed * Time.deltaTime); //works but not locked to x axis

		if (playerHasntJumped == true) 
		{
			//lock the sweeper to the x axis until the player has jumped. check is the player height is > then the sweepers.
		}

		if (playerHasJumped == true) 
		{
			//once the player has jumped, remove the lock and use the same jump code from the player movement script. 
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.name == "PlayerSprite") 
		{
			playerStunned = true;
		}
	}
}
