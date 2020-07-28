using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {

	public List<Image> puntajes;
	public List<Button> levelButtons;
	public List<Stars> stars;

	// Use this for initialization
	void Start () {
		Events.LevelSelectorUpdate += LevelSelectorUpdate;
		Events.AddStar += AddStar;
		Events.AreaChange += AreaChange;
        Events.ResetRecorrido += Init;
        Init();
    }

    public void Init() {
        for (int i = 0; i < Data.Instance.levelData.currentLevelIndex + 1; i++) {
            levelButtons[i].interactable = true;
            if (i < Data.Instance.levelData.currentLevelIndex) {
                puntajes[i].fillAmount = 1f;
            } else {
                LevelSelectorUpdate(i);
            }
        }

        for (int i = 0; i < stars.Count; i++) {
            stars[i].SetStars(Data.Instance.levelData.levels[i].stars);
        }
    }

	void OnDestroy(){
		Events.LevelSelectorUpdate -= LevelSelectorUpdate;
		Events.AddStar -= AddStar;
        Events.AreaChange -= AreaChange;
        Events.ResetRecorrido -= Init;
    }

	void AddStar(int index){
		stars[index].SetStars(Data.Instance.levelData.levels[index].stars);
	}

	void LevelSelectorUpdate(int index){
		LevelsData.Level l = Data.Instance.levelData.CurrentLevel;
		if (l.levelCompleted && l.localPoints == 0)
			puntajes [index].fillAmount = 1;
		else
			puntajes [index].fillAmount = 1f * l.localPoints / l.length;
	}

	void AreaChange(int id){
		if(Data.Instance.levelData.currentLevelIndex>0)
			levelButtons [Data.Instance.levelData.currentLevelIndex-1].interactable = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
