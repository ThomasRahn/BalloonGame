using UnityEngine;
using System.Collections;

public class Missle : MonoBehaviour {


	public float speed = 20.0f;
	public GameObject target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider col){
		Debug.Log ("hit");
		Destroy (col.gameObject);
		GameController.UpdateScore (10);
		Destroy (this);
	}
}
