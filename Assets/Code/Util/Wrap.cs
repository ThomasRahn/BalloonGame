using UnityEngine;
using System.Collections;

public class Wrap : MonoBehaviour {
	public float limit = 20.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = this.transform.position;
		Vector3 newPosition = position;
		if(position.x > limit || position.x < -limit){
			newPosition.x = -position.x;
			if(newPosition.x < 0){
				newPosition.x += 0.01f;
			}else{
				newPosition.x -= 0.01f;
			}
		}
		if(position.y > limit || position.y < -limit){
			newPosition.y = -position.y;
			if(newPosition.y < 0){
				newPosition.y += 0.01f;
			}else{
				newPosition.y -= 0.01f;
			}
		}
		if(position.z > limit || position.z < -limit){
			newPosition.z = -position.z;
			if(newPosition.z < 0){
				newPosition.z += 0.01f;
			}else{
				newPosition.z -= 0.01f;
			}
		}
		this.transform.position = newPosition;
	}
}
