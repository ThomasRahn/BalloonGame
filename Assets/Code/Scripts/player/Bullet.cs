using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void Start(){
		this.rigidbody.freezeRotation = true;
	}
	void OnTriggerEnter(Collider col){
		GameObject obj = col.gameObject;

		if(obj.CompareTag("balloon")){
			obj.GetComponent<Balloon>().Hit();
			Destroy(this.gameObject);
		}
		if(obj.CompareTag("enemyBullet")){
			Destroy(obj);
			Destroy(this.gameObject);
		}
	}
}
