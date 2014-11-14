using UnityEngine;
using System.Collections;
using System;

public class Menu : MonoBehaviour {

	private int numberOfBalloons;
	private string balloons = "";
	// Use this for initialization
	void Start () {
		numberOfBalloons = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI (){
		Debug.Log ("Ho");
		if (GUI.Button (new Rect (Screen.width/2,Screen.height/2 - 55,80,20), "Play")) {
			if(numberOfBalloons >= 0){
				PlayerPrefs.SetInt("Balloons", numberOfBalloons);
				Application.LoadLevel ("main");
			}
		}
		GUI.Label (new Rect (Screen.width/2,Screen.height/2 - 25,200,20), "Enter the number of balloons");

		balloons = GUI.TextField(new Rect(Screen.width/2,Screen.height/2, 200, 20), balloons, 25);
		if(balloons != "" && int.TryParse(balloons, out numberOfBalloons))
			numberOfBalloons = int.Parse (balloons);

	}
}
