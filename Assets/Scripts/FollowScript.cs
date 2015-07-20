using UnityEngine;
using System.Collections;

public class FollowScript : MonoBehaviour {

	public GameObject target;


	// Update is called once per frame
	void Update () {
		if (this.gameObject.transform.position != target.gameObject.transform.position) {
			transform.position = Vector3.Lerp (transform.position, target.transform.position, 2 * Time.deltaTime);
		}
	}
}
