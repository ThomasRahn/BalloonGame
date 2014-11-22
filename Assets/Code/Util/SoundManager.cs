using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {

	public enum sound {
		BalloonPop = 0,
		Shoot = 1,
		Die = 2,
	};
	public static List<string> sounds = new List<string>();
	private static AudioSource source;
	// Use this for initialization
	void Start () {
		sounds.Add ("Sounds/Balloons/pop");
		sounds.Add ("Sounds/Player/shoot");
		sounds.Add ("Sounds/Player/die");
		source = this.gameObject.GetComponent<AudioSource> ();
	}

	public static void PlaySound(sound soundEnum){
		source.clip = Resources.Load (sounds [(int)soundEnum]) as AudioClip;
		if(source.clip != null){
			source.Play ();
		}
	}
}
