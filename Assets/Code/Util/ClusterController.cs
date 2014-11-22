using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClusterController : MonoBehaviour {

	public static List<GameObject> balloons = new List<GameObject>();
	public static int totalNumberOfBalloons;
	public static int numberOfBalloons;
	public static int numberOfEnemies;
	private static bool thirty;
	private static bool sixty;
	private static bool ninety;
	private static bool speedBoost;

	public string status;
	// Use this for initialization
	void Start () {
		numberOfBalloons = 0;
		numberOfEnemies = 3;
		thirty = false;
		sixty = false;
		ninety = false;
		speedBoost = false;
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
		if(balLeft < 0.2f && !speedBoost){
			speedBoost = true;
			increaseSpeed();
		}
		status = numberOfBalloons + " " + !GameController.gameOver + numberOfEnemies;
		if(numberOfBalloons <= 0 && !GameController.gameOver && numberOfEnemies <= 0){
			GameController.WinGame();
		}
	}

	private void increaseSpeed(){
		foreach(GameObject balloon in balloons){
			balloon.rigidbody.AddForce(new Vector3(0,5,0));
		}
	}

	public static void SpawnBalloons (){
		int reverse = 1;
		int playerPref = PlayerPrefs.GetInt ("Balloons");
		for(int i = 0; i < playerPref; i++){
			if(i % 2 == 0){
				reverse = reverse *-1;
			}
			Vector3 position = new Vector3(Random.Range(3,20) * reverse, Random.Range(3,20) * reverse, Random.Range(3,20) * reverse);
			Object enemy = Resources.Load ("Prefabs/BalloonModel");
			GameObject bal = Instantiate(enemy) as GameObject;
			bal.transform.position = position;
			numberOfBalloons++;
			totalNumberOfBalloons++;
			balloons.Add(bal);
		}
		Radar.CreateRadar (balloons);
	}

	public static void BalloonPoped(GameObject obj){
		balloons.Remove (obj);
		Radar.killBalloon ();
		numberOfBalloons--;
	}

	private static void spawnEnemy(){
		Object obj = Resources.Load ("Prefabs/EnemyModel");
		GameObject enemy = Instantiate(obj, new Vector3(-5,5,-5), Quaternion.identity) as GameObject;
		Radar.AddEnemy (enemy);
	}


	public static List<GameObject> GetAllBalloons(){
		return balloons;
	}
	public static void KillEnemy(){
		Radar.RemoveEnemy ();
		numberOfEnemies--;
	}
}
