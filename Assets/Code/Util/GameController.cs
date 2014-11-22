using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {


	public static int lives;
	public static int score;
	public static bool gameOver;
	public static bool dead;
	public Texture hearts;
	// Use this for initialization
	void Start () {
		ClusterController.SpawnBalloons ();
		score = 0;
		lives = 3;
		Screen.lockCursor = true;
		dead = false;
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject.FindGameObjectWithTag ("score").guiText.text = "Score: " + score;
		if(gameOver){
			StartCoroutine(Respawn());
		}
		if(dead){
			StartCoroutine (Reset());
		}
	}
	void OnGUI(){
		for(int i = 0; i < lives; i++){
			if(GUI.Button(new Rect(Screen.width - (50 + 32*i),25, 32,27), hearts, GUIStyle.none)){
			}
		}
	}
	public static void UpdateScore(int i){
		score += i;
	}

	public static void Die(){
		Fading.Fade = true;
		lives--;
		GameObject.FindGameObjectWithTag ("status").guiText.text = "You have died";
		if(lives == 0){
			gameOver = true;
		}else{
			dead = true;
		}
	}

	IEnumerator Reset(){
		yield return new WaitForSeconds (4);
		GameObject.FindGameObjectWithTag ("status").guiText.text = "";
		this.gameObject.GetComponent<Fading> ().Reset ();
		dead = false;
	}

	public static void WinGame(){
		GameObject.FindGameObjectWithTag ("status").guiText.text = "You have Won the game";
		GameObject fireworks = GameObject.FindGameObjectWithTag ("winner");
		fireworks.particleSystem.Play ();
		gameOver = true;
	}

	public IEnumerator Respawn(){
		yield return new WaitForSeconds (10);
		GameObject.FindGameObjectWithTag ("Player").transform.rotation = Quaternion.identity;
		Application.LoadLevel ("menu");
	}
}
