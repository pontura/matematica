using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TextsManager : MonoBehaviour {

	public Text kunakText;
	public Text buttonText;
	public GameObject jugarButton;
	public Tween textTween;
	public Tween buttonTween;

	int dialog_index;

	// Use this for initialization
	void Start () {
		Events.NextDialog += Init;
		Events.AllAreasCompleted += AllAreasCompleted;
		Invoke ("Init", 1);
	}

	void OnDestroy(){
		Events.NextDialog -= Init;
		Events.AllAreasCompleted -= AllAreasCompleted;
	}

	void AllAreasCompleted(){
		dialog_index = 0;
	}

	void Init(){
		kunakText.transform.parent.gameObject.SetActive (true);
		ExternalTexts.ExternalText eText = null;
		if (Data.Instance.levelData.triviaCount == 0) {
			if (Data.Instance.levelData.kunakState == LevelsData.KunakStates.inicio) {
				eText = Data.Instance.externalTexts.texts [0];
			} else if (Data.Instance.levelData.kunakState == LevelsData.KunakStates.area) {
				jugarButton.SetActive (true);
                if(!Data.Instance.levelData.allAreasCompleted)
				    eText = Array.Find (Data.Instance.externalTexts.texts, e => e.area_id == Data.Instance.levelData.currentLevel && e.dialog_index==0);
                else
                    eText = Array.Find(Data.Instance.externalTexts.texts, e => e.area_id == Data.Instance.levelData.playingLevelIndex+1 && e.dialog_index == 0);
                dialog_index = 0;
				if (eText.next)
					Data.Instance.levelData.kunakState = LevelsData.KunakStates.dialog;
			} else if (Data.Instance.levelData.kunakState == LevelsData.KunakStates.dialog) {
				jugarButton.SetActive (true);
                if (!Data.Instance.levelData.allAreasCompleted)
                    eText = Array.Find (Data.Instance.externalTexts.texts, e => e.area_id == Data.Instance.levelData.currentLevel && e.dialog_index==dialog_index);
                else
                    eText = Array.Find(Data.Instance.externalTexts.texts, e => e.area_id == Data.Instance.levelData.playingLevelIndex+1 && e.dialog_index == dialog_index);
                if (!eText.next)
					Data.Instance.levelData.kunakState = LevelsData.KunakStates.area;
			}
		} else if (Data.Instance.levelData.kunakState == LevelsData.KunakStates.inicio) {
			if (Data.Instance.levelData.allAreasCompleted) {
				eText = Data.Instance.externalTexts.texts [18];
			} else {
				//jugarButton.SetActive (true);
				eText = Data.Instance.externalTexts.texts [1];
			}
		} else if (Data.Instance.levelData.kunakState == LevelsData.KunakStates.area) {			
			jugarButton.SetActive (true);
            if (!Data.Instance.levelData.allAreasCompleted)
                eText = Array.Find (Data.Instance.externalTexts.texts, e => e.area_id == Data.Instance.levelData.currentLevel && e.dialog_index==0);
            else
                eText = Array.Find (Data.Instance.externalTexts.texts, e => e.area_id == Data.Instance.levelData.playingLevelIndex+1 && e.dialog_index==0);
			dialog_index = 0;
			if (eText.next) 
				Data.Instance.levelData.kunakState = LevelsData.KunakStates.dialog;
		} else if (Data.Instance.levelData.kunakState == LevelsData.KunakStates.dialog) {
			jugarButton.SetActive (true);
            if (!Data.Instance.levelData.allAreasCompleted)
                eText = Array.Find (Data.Instance.externalTexts.texts, e => e.area_id == Data.Instance.levelData.currentLevel && e.dialog_index==dialog_index);
            else
                eText = Array.Find (Data.Instance.externalTexts.texts, e => e.area_id == Data.Instance.levelData.playingLevelIndex+1 && e.dialog_index == dialog_index);
            if (!eText.next)
				Data.Instance.levelData.kunakState = LevelsData.KunakStates.area;
		}else if (Data.Instance.levelData.kunakState == LevelsData.KunakStates.allcomplete) {
			jugarButton.SetActive (true);
			eText = Array.Find (Data.Instance.externalTexts.texts, e => e.area_id == 8 && e.dialog_index==dialog_index);
			if (!eText.next)
				Data.Instance.levelData.kunakState = LevelsData.KunakStates.area;
		}
		kunakText.text = eText.frase;
		buttonText.text = eText.button_text;
		textTween.doTween = true;
		buttonTween.doTween = true;
		if (eText.next) {
			dialog_index++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
