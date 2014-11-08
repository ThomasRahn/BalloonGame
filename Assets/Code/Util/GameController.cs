using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {


	public static int lives;
	public static int score;
	// Use this for initialization
	void Start () {
		ClusterController.SpawnBalloons ();
		score = 0;

	}
	
	// Update is called once per frame
	void Update () {
		GameObject.FindGameObjectWithTag ("score").guiText.text = "Score: " + score;
	}

	public static void UpdateScore(int i){
		score += i;
	}
}
