﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextsManager : MonoBehaviour {

	public Text kunakText;
	public Text buttonText;

	// Use this for initialization
	void Start () {
		Invoke ("Init", 1);
	}

	void Init(){
		if (Data.Instance.levelData.triviaCount == 0) {
			kunakText.text = Data.Instance.externalTexts.texts [0].frase;
			buttonText.text = Data.Instance.externalTexts.texts [0].button_text;
		} else if (Data.Instance.levelData.kunakState == LevelsData.KunakStates.inicio) {
			if (Data.Instance.levelData.allAreasCompleted) {
				kunakText.text = Data.Instance.externalTexts.texts [18].frase;
				buttonText.text = Data.Instance.externalTexts.texts [18].button_text;
			} else {
				kunakText.text = Data.Instance.externalTexts.texts [1].frase;
				buttonText.text = Data.Instance.externalTexts.texts [1].button_text;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
