using UnityEngine;
using System.Collections;

public class Fading : MonoBehaviour {

	public static bool Fade = false;
	public Texture2D fadeOutTexture;
	public float fadeSpeed = 0.8f;
	private static float alpha = 0.0f;
	private int fadeDir = 1;
	private int drawDepth = -1000;

	void OnGUI(){
		if(Fade){
			alpha += fadeDir * fadeSpeed * Time.deltaTime;

			alpha = Mathf.Clamp01(alpha);

			GUI.color = new Color(GUI.color.r,GUI.color.g, GUI.color.b, alpha);
			GUI.depth = drawDepth;

			GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),fadeOutTexture);
		}
	}
	public void Reset (){
		Fade = false;
		alpha = 0.0f;
	}
}
