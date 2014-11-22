using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Radar : MonoBehaviour {
	public static List<GameObject> balloons;
	public static GameObject playerItem;
	public static List<GameObject> enemies;
	// Use this for initialization
	void Start () {
		balloons = new List<GameObject> ();
		enemies = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(playerItem == null){
			playerItem = Instantiate(Resources.Load ("Prefabs/RadarItem/PlayerItem")) as GameObject;
			playerItem.transform.parent = GameObject.FindGameObjectWithTag ("radar").transform;
			playerItem.transform.position = new Vector3(0,0,0);
		}
		playerItem.transform.localPosition = Vector3.Scale(GameObject.FindGameObjectWithTag ("Player").transform.position, new Vector3(0.01f,0.01f,0.01f));	
		if (balloons != null && balloons.Count > 0) {
			List<GameObject> clusters = ClusterController.GetAllBalloons();
			for(int i = 0; i < clusters.Count; i++){
				balloons[i].transform.localPosition = Vector3.Scale(clusters[i].transform.position,new Vector3(0.01f,0.01f,0.01f));	
			}
		}

		GameObject[] hotAir = GameObject.FindGameObjectsWithTag ("enemy");
		for(int i = 0; i < enemies.Count; i++){
			if(i < hotAir.Length){
				enemies[i].transform.localPosition = Vector3.Scale(hotAir[i].transform.position,new Vector3(0.01f,0.01f,0.01f));	
			}
		}

	}

	public static void CreateRadar(List<GameObject> balls){
		foreach(GameObject balloon in balls){
			Object obj = Resources.Load("Prefabs/RadarItem/balloonRadar");
			GameObject item = Instantiate(obj) as GameObject;
			item.transform.rotation = balloon.transform.rotation;
			item.transform.parent = GameObject.FindGameObjectWithTag("radar").transform;
			item.transform.localPosition = Vector3.Scale(balloon.transform.position,new Vector3(0.01f,0.01f,0.01f));	
			balloons.Add (item);
		}

	}

	public static void AddEnemy(GameObject enemy){
		Object obj = Resources.Load("Prefabs/RadarItem/EnemyItemModel");
		GameObject item = Instantiate(obj) as GameObject;
		item.transform.parent = GameObject.FindGameObjectWithTag("radar").transform;
		item.transform.localPosition = Vector3.Scale(enemy.transform.position,new Vector3(0.01f,0.01f,0.01f));	
		enemies.Add (item);
	}

	public static void RemoveEnemy(){
		if(enemies.Count > 0){
			Destroy (enemies[0]);
			enemies.RemoveAt(0);
		}
	}

	public static void killBalloon(){
		if(balloons.Count > 0){
			Destroy (balloons[0]);
			balloons.RemoveAt(0);
		}
	}
}
