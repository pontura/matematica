using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TextsManager : MonoBehaviour {

	public Text kunakText;
	public Text buttonText;

	int dialog_index;

	// Use this for initialization
	void Start () {
		Events.NextDialog += Init;
		Invoke ("Init", 1);
	}

	void OnDestroy(){
		Events.NextDialog -= Init;
	}

	void Init(){
		kunakText.transform.parent.gameObject.SetActive (true);
		ExternalTexts.ExternalText eText = null;
		if (Data.Instance.levelData.triviaCount == 0) {
			if (Data.Instance.levelData.kunakState == LevelsData.KunakStates.inicio) {
				eText = Data.Instance.externalTexts.texts [0];
			} else if (Data.Instance.levelData.kunakState == LevelsData.KunakStates.area) {
				buttonText.transform.parent.gameObject.SetActive (true);
				eText = Array.Find (Data.Instance.externalTexts.texts, e => e.area_id == Data.Instance.levelData.currentLevel && e.dialog_index==0);
				dialog_index = 0;
			} else if (Data.Instance.levelData.kunakState == LevelsData.KunakStates.dialog) {
				buttonText.transform.parent.gameObject.SetActive (true);
				eText = Array.Find (Data.Instance.externalTexts.texts, e => e.area_id == Data.Instance.levelData.currentLevel && e.dialog_index==dialog_index);
				if (!eText.next)
					Data.Instance.levelData.kunakState = LevelsData.KunakStates.area;
			}
		} else if (Data.Instance.levelData.kunakState == LevelsData.KunakStates.inicio) {
			if (Data.Instance.levelData.allAreasCompleted) {
				eText = Data.Instance.externalTexts.texts [18];
			} else {
				buttonText.transform.parent.gameObject.SetActive (true);
				eText = Data.Instance.externalTexts.texts [1];
			}
		} else if (Data.Instance.levelData.kunakState == LevelsData.KunakStates.area) {			
			buttonText.transform.parent.gameObject.SetActive (true);
			eText = Array.Find (Data.Instance.externalTexts.texts, e => e.area_id == Data.Instance.levelData.currentLevel && e.dialog_index==0);
			dialog_index = 0;
		} else if (Data.Instance.levelData.kunakState == LevelsData.KunakStates.dialog) {
			buttonText.transform.parent.gameObject.SetActive (true);
			eText = Array.Find (Data.Instance.externalTexts.texts, e => e.area_id == Data.Instance.levelData.currentLevel && e.dialog_index==dialog_index);
			if (!eText.next)
				Data.Instance.levelData.kunakState = LevelsData.KunakStates.area;
		}
		kunakText.text = eText.frase;
		buttonText.text = eText.button_text;
		if (eText.next) {
			dialog_index++;
			Data.Instance.levelData.kunakState = LevelsData.KunakStates.dialog;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
