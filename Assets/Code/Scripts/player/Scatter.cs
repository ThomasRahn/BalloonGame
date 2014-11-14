using UnityEngine;
using System.Collections;

public class Scatter : MonoBehaviour {

	public GameObject target;
	private float speed = 5.0f;
	// Use this for initialization
	void Start () {
	
	}


	// Update is called once per frame
	void Update () {
		if(target != null){
			this.transform.Translate((target.transform.position - this.transform.position) * Time.deltaTime * speed);
		}
	}

	public void SetTarget(GameObject obj){
		this.target = obj;
	}
}
