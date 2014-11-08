using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.rigidbody.velocity = new Vector3 (Random.Range (2, 3), 0, Random.Range (2, 3));
	}
	
	// Update is called once per frame
	void Update () {

		//Shoot at player
	}
}
