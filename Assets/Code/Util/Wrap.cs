using UnityEngine;
using System.Collections;

public class Wrap : MonoBehaviour {
	public float limit = 40.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = this.transform.position;
		Vector3 newPosition = position;
		if(position.x > limit || position.x < -limit){
			newPosition.x = -position.x;
		}
		if(position.y > limit || position.y < -limit){
			newPosition.y = -position.y;
		}
		if(position.z > limit || position.z < -limit){
			newPosition.z = -position.z;
		}
		this.transform.position = newPosition;
	}
}
