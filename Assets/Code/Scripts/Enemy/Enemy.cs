using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private int killScore = 10;
	public int life = 5;
	public float shootDelay = 2.0f;
	private GameObject player;
	// Use this for initialization
	void Start () {
		this.rigidbody.velocity = new Vector3 (Random.Range (2, 3), 0, Random.Range (2, 3));
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {

		//Shoot at player
		shootDelay -= Time.deltaTime;
		if(shootDelay <= 0.0f){
			Shoot();
			shootDelay = 2.0f;
		}
	}

	private void Shoot(){
		GameObject shoot = Instantiate (Resources.Load("Prefabs/EnemyBalloon")) as GameObject;
		shoot.transform.position = this.transform.position;
		shoot.rigidbody.velocity = (player.transform.position - shoot.transform.position);
		Destroy (shoot, 1.5f);
	}
	void OnTriggerEnter(Collider col){

		GameObject obj = col.gameObject;
		if(obj.tag == "bullet"){
			Destroy(col);
			life--;
			if(life == 0){
				GameController.UpdateScore(killScore);
				Destroy (this.gameObject);
			}
		}
		if (obj.tag == "missle") {
			Debug.Log("hit");
			Destroy (col.gameObject);
			GameController.UpdateScore (killScore);
			Destroy (this.gameObject);
		}
	}
}
