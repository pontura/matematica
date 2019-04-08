﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour {

	public GameObject loading;
	public GameObject playButton;
	public GameObject sesionButton;
	public float step;

	Image loadingBar;
	float fill;
	bool done;
	Tween buttonTween;
	Tween sesionTween;

	// Use this for initialization
	void Start () {
		loadingBar = GetComponent<Image> ();
		buttonTween = playButton.GetComponent<Tween> ();
		sesionTween = sesionButton.GetComponent<Tween> ();
		playButton.SetActive (false);
		sesionButton.SetActive (false);
	}

	public void SetFill(float f){
		fill = f;
	}
	
	// Update is called once per frame
	void Update () {
		if (loadingBar.fillAmount < fill) {
			loadingBar.fillAmount += step;
		} else if (!done && fill>0.98f) {
			//Debug.Log ("aca");
			Events.KunakSfx(true);
			loading.SetActive (false);
			playButton.SetActive (true);
            if(!Data.Instance.esAlumno)
			    sesionButton.SetActive (true);
			//buttonTween.doTween = true;
			done = true;
		}
	}
}
