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
		int reverse = 1;
		for(int i = 0; i < Random.Range(50,100);i++){
			if(i % 2 == 0){
				reverse = reverse *-1;
			}
			Vector3 position = new Vector3(Random.Range(3,20) * reverse, Random.Range(3,20) * reverse, Random.Range(3,20) * reverse);
			Object enemy = Resources.Load ("Prefabs/BalloonModel");
			GameObject bal = Instantiate(enemy) as GameObject;
			bal.transform.position = position;
			numberOfBalloons++;
			totalNumberOfBalloons++;
		}
	}

	public static void BalloonPoped(){
		numberOfBalloons--;
	}

	private static void spawnEnemy(){
		Object obj = Resources.Load ("Prefabs/EnemyModel");
		GameObject enemy = Instantiate(obj, new Vector3(-5,5,-5), Quaternion.identity) as GameObject;
	}
}
