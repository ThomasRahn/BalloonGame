using UnityEngine;
using System.Collections;

public class Balloon : MonoBehaviour {

	public float speed = 3.0f;
	// Use this for initialization
	void Start () {
		this.rigidbody.AddForce (new Vector3 (Random.Range(1,3) * speed,Random.Range(1,3)  * speed,Random.Range(1,3)  * speed));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
