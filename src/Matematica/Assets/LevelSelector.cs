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
