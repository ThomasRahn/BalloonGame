using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {


	public static int lives;
	public static int score;
	public static bool gameOver;
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
		if(gameOver){
			StartCoroutine(Respawn());
		}
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
		gameOver = true;
	}

	public static void WinGame(){
		GameObject.FindGameObjectWithTag ("status").guiText.text = "You have Won the game";
		GameObject obj = GameObject.FindGameObjectWithTag ("tower");
		obj.transform.position = Camera.main.transform.position + (Camera.main.transform.forward * 20.0f);
		GameObject[] towerPieces = GameObject.FindGameObjectsWithTag ("towerPiece");
		Debug.Log (towerPieces.Length);
		foreach(GameObject o in towerPieces){
			o.renderer.enabled = true;
		}
		gameOver = true;
	}

	public IEnumerator Respawn(){
		yield return new WaitForSeconds (10);
		Application.LoadLevel ("menu");
	}
}
