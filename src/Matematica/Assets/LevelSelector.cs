using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {

	public List<Image> puntajes;
	public List<Button> levelButtons;

	// Use this for initialization
	void Start () {
		Events.LevelSelectorUpdate += LevelSelectorUpdate;
		Events.AreaChange += AreaChange;
		for (int i = 0; i < Data.Instance.levelData.currentLevelIndex+1; i++) {			
			levelButtons [i].interactable = true;
			if (i < Data.Instance.levelData.currentLevelIndex) {
				puntajes [i].fillAmount = 1f;
			} else {
				LevelSelectorUpdate (i);
			}
		}
	}

	void OnDestroy(){
		Events.LevelSelectorUpdate -= LevelSelectorUpdate;
		Events.AreaChange -= AreaChange;
	}

	void LevelSelectorUpdate(int index){
		LevelsData.Level l = Data.Instance.levelData.CurrentLevel;
		puntajes [index].fillAmount = 1f * l.localPoints / l.length;
	}

	void AreaChange(int id){
		levelButtons [Data.Instance.levelData.currentLevelIndex].interactable = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
