using UnityEngine;
using System.Collections;

public class TurretController : MonoBehaviour {
	public GameObject player;
	public Vector3 playerPos;

	void awake () {

	}
	// Use this for initialization
	void Start () {
		//playerPos = player.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () 
	{
		playerPos = player.transform.position;
		LookAtPlayer();
		//this.transform.LookAt(playerPos);
		//this.transform.Rotate(new Vector3(0,-90,0),Space.Self);
	}

	void LookAtPlayer()
	{
		this.transform.LookAt (playerPos);
		this.transform.Rotate(new Vector3(0,-90,90),Space.Self);
	}
}
