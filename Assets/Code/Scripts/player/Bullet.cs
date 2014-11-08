﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		GameObject obj = col.gameObject;

		if(obj.tag == "balloon"){
			GameController.UpdateScore(1);
			ClusterController.BalloonPoped();
			Destroy(obj);
			Destroy(this);
		}
	}
}