using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClusterController : MonoBehaviour {

	public static List<GameObject> clusters = new List<GameObject>();
	public static int totalNumberOfBalloons;
	public static int numberOfBalloons;

	private static bool thirty = false;
	private static bool sixty = false;
	private static bool ninety = false;
	// Use this for initialization
	void Start () {
		numberOfBalloons = 0;
	}
	
	// Update is called once per frame
	void Update () {

		float balLeft = numberOfBalloons / (totalNumberOfBalloons * 1.0f);
		if (balLeft < 0.7f && !thirty) {
			thirty = true;
			spawnEnemy();
		}
		if (balLeft < 0.4f && !sixty) {
			sixty = true;
			spawnEnemy();
		}
		if (balLeft < 0.1f && !ninety) {
			ninety = true;
			spawnEnemy();
		}
	}

	public static void SpawnBalloons (){
		for(int i = 0; i < Random.Range(10,40);i++){
			Vector3 position = new Vector3(Random.Range(2,4), Random.Range(2,4), Random.Range(2,4));
			Object enemy = Resources.Load ("Prefabs/Balloon");
			GameObject bal = Instantiate(enemy, position, Quaternion.identity) as GameObject;
			numberOfBalloons++;
			totalNumberOfBalloons++;
		}
	}

	public static void BalloonPoped(){
		numberOfBalloons--;
	}

	private static void spawnEnemy(){
		Object obj = Resources.Load ("Prefabs/Enemy");
		GameObject enemy = Instantiate(obj, new Vector3(-5,5,-5), Quaternion.identity) as GameObject;
	}
}
