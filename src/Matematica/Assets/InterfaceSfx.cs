using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceSfx : MonoBehaviour {

	public AudioClip click;
	public AudioClip combo;
	public AudioClip winLevel;
	public AudioClip winGame;

	AudioSource source;

	// Use this for initialization
	void Awake () {
		source = GetComponent<AudioSource> ();
	}

	public void ClickSfx(float _pitch){
		source.pitch = _pitch;
		source.PlayOneShot (click);
	}

	public void ComboSfx(){
		source.PlayOneShot (combo);
	}

	public void WinLevelSfx(){
		source.PlayOneShot (winLevel);
	}

	public void WinGameSfx(){
		source.PlayOneShot (winGame);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
