using UnityEngine;
using System.Collections;

public class Balloon : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.rigidbody.freezeRotation = true;

	}
	
	// Update is called once per frame
	void Update () {
		this.rigidbody.velocity = new Vector3 (0, 5, 0);
	}
}
