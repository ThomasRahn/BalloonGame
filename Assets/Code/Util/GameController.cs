using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {


	public static int lives;
	public static int score;
	// Use this for initialization
	void Start () {
		ClusterController.SpawnBalloons ();
		score = 0;
		lives = 3;
		Screen.lockCursor = true;

	}
	
	// Update is called once per frame
	void Update () {
		GameObject.FindGameObjectWithTag ("score").guiText.text = "Score: " + score;
	}

	public static void UpdateScore(int i){
		score += i;
	}

	public static void Die(){
		lives--;
		GameObject.FindGameObjectWithTag ("status").guiText.text = "You have died";
		if(lives == 0){
			GameOver();
		}
	}

	private static void GameOver(){
		Application.LoadLevel("main");
	}

	public static void WinGame(){

	}
}
