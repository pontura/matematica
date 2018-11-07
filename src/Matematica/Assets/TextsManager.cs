using System.Collections;
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
		kunakText.transform.parent.gameObject.SetActive (true);
		if (Data.Instance.levelData.triviaCount == 0) {
			if (Data.Instance.levelData.kunakState == LevelsData.KunakStates.inicio) {
				kunakText.text = Data.Instance.externalTexts.texts [0].frase;
				buttonText.text = Data.Instance.externalTexts.texts [0].button_text;
			} else {
				buttonText.transform.parent.gameObject.SetActive (true);
				kunakText.text = Data.Instance.externalTexts.texts [2].frase;
				buttonText.text = Data.Instance.externalTexts.texts [2].button_text;
			}
		} else if (Data.Instance.levelData.kunakState == LevelsData.KunakStates.inicio) {
			if (Data.Instance.levelData.allAreasCompleted) {
				kunakText.text = Data.Instance.externalTexts.texts [18].frase;
				buttonText.text = Data.Instance.externalTexts.texts [18].button_text;
			} else {
				buttonText.transform.parent.gameObject.SetActive (true);
				kunakText.text = Data.Instance.externalTexts.texts [1].frase;
				buttonText.text = Data.Instance.externalTexts.texts [1].button_text;
			}
		} else if (Data.Instance.levelData.kunakState == LevelsData.KunakStates.area) {
			buttonText.transform.parent.gameObject.SetActive (true);
			if (Data.Instance.levelData.currentLevel == 1) {
				kunakText.text = Data.Instance.externalTexts.texts [2].frase;
				buttonText.text = Data.Instance.externalTexts.texts [2].button_text;
			}else if (Data.Instance.levelData.currentLevel == 2) {
				kunakText.text = Data.Instance.externalTexts.texts [4].frase;
				buttonText.text = Data.Instance.externalTexts.texts [4].button_text;
			}else if (Data.Instance.levelData.currentLevel == 3) {
				kunakText.text = Data.Instance.externalTexts.texts [6].frase;
				buttonText.text = Data.Instance.externalTexts.texts [6].button_text;
			}else if (Data.Instance.levelData.currentLevel == 4) {
				kunakText.text = Data.Instance.externalTexts.texts [8].frase;
				buttonText.text = Data.Instance.externalTexts.texts [8].button_text;
			}else if (Data.Instance.levelData.currentLevel == 5) {
				kunakText.text = Data.Instance.externalTexts.texts [10].frase;
				buttonText.text = Data.Instance.externalTexts.texts [10].button_text;
			}else if (Data.Instance.levelData.currentLevel == 6) {
				kunakText.text = Data.Instance.externalTexts.texts [12].frase;
				buttonText.text = Data.Instance.externalTexts.texts [12].button_text;
			}else if (Data.Instance.levelData.currentLevel == 7) {
				kunakText.text = Data.Instance.externalTexts.texts [14].frase;
				buttonText.text = Data.Instance.externalTexts.texts [14].button_text;
			}
		} else if (Data.Instance.levelData.kunakState == LevelsData.KunakStates.subarea) {
			buttonText.transform.parent.gameObject.SetActive (true);
			if (Data.Instance.levelData.currentLevel == 1) {
				kunakText.text = Data.Instance.externalTexts.texts [3].frase;
				buttonText.text = Data.Instance.externalTexts.texts [3].button_text;
			}else if (Data.Instance.levelData.currentLevel == 2) {
				kunakText.text = Data.Instance.externalTexts.texts [5].frase;
				buttonText.text = Data.Instance.externalTexts.texts [5].button_text;
			}else if (Data.Instance.levelData.currentLevel == 3) {
				kunakText.text = Data.Instance.externalTexts.texts [7].frase;
				buttonText.text = Data.Instance.externalTexts.texts [7].button_text;
			}else if (Data.Instance.levelData.currentLevel == 4) {
				kunakText.text = Data.Instance.externalTexts.texts [9].frase;
				buttonText.text = Data.Instance.externalTexts.texts [9].button_text;
			}else if (Data.Instance.levelData.currentLevel == 5) {
				kunakText.text = Data.Instance.externalTexts.texts [11].frase;
				buttonText.text = Data.Instance.externalTexts.texts [11].button_text;
			}else if (Data.Instance.levelData.currentLevel == 6) {
				kunakText.text = Data.Instance.externalTexts.texts [13].frase;
				buttonText.text = Data.Instance.externalTexts.texts [13].button_text;
			}else if (Data.Instance.levelData.currentLevel == 7) {
				kunakText.text = Data.Instance.externalTexts.texts [15].frase;
				buttonText.text = Data.Instance.externalTexts.texts [15].button_text;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
