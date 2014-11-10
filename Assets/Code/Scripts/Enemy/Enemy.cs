using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private int killScore = 10;
	public int life = 5;
	// Use this for initialization
	void Start () {
		this.rigidbody.velocity = new Vector3 (Random.Range (2, 3), 0, Random.Range (2, 3));
	}
	
	// Update is called once per frame
	void Update () {

		//Shoot at player
	}

	void OnTriggerEnter(Collider col){

		GameObject obj = col.gameObject;
		if (obj.tag == "Player") {
			//Kill player
			GameController.UpdateScore(killScore);
			Destroy (this);
		}
		if(obj.tag == "Bullet"){
			life--;
			if(life == 0){
				GameController.UpdateScore(killScore);
				Destroy (this);
			}
		}
	}
}
