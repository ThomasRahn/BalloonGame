using UnityEngine;
using System.Collections;

public class Balloon : MonoBehaviour {

	public int lives = 3;
	// Use this for initialization
	void Start () {
		this.rigidbody.freezeRotation = true;

	}
	
	// Update is called once per frame
	void Update () {
		this.rigidbody.velocity = new Vector3 (0, 5, 0);
	}

	public void Hit(){
		lives--;

		if(lives == 0){
			ClusterController.BalloonPoped(this.gameObject);
			GameController.UpdateScore(2);
			Destroy(this.gameObject);
		}else{
			GameController.UpdateScore(1);
			if(lives == 2){
				this.gameObject.renderer.material.color = Color.yellow;
				this.transform.localScale = new Vector3(35,35,35);
			}else{
				this.gameObject.renderer.material.color = Color.red;
				this.transform.rigidbody.AddForce(new Vector3(0,4,0) * 100.0f);
				this.transform.localScale = new Vector3(25,25,25);
			}
		}
	}
}
