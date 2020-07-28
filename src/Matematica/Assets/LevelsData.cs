using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelsData : MonoBehaviour {

	public List<Level> levels;
	public int currentLevel;
	public int currentLevelIndex;
	public int subAreaIndex;

	public int playingLevelIndex;

	public int triviaCount;

	public bool allAreasCompleted;

	public bool replay;
	int replayAreaId;

	bool loading;

	public KunakStates kunakState;
	public enum KunakStates{
		inicio,
		area,
		dialog,
		allcomplete
	}

	[Serializable]
	public class Level
	{
		public int id;
		public int length;
		public int localPoints;
		public int lastLevelQuestion;
		public bool unlocked;
		public bool levelCompleted;
		public int stars;
		public int comboCondition;
		public int comboReward;
	}

	// Use this for initialization
	void Start () {
        loading = true;
        kunakState = KunakStates.inicio;
        //Events.AddScore += AddScore;
        Events.ReplayArea += ReplayArea;
        Init();
        loading = false;
    }

    public void Init() {        
        triviaCount = PlayerPrefs.GetInt("triviaCount");
        int count = -1;
        for (int i = 0; i < levels.Count; i++) {
            count += levels[i].length;
            levels[i].lastLevelQuestion = count;
            levels[i].stars = PlayerPrefs.GetInt("stars_" + i);
            levels[i].localPoints = 0;
            levels[i].levelCompleted = false;
            if (i > 0)
                levels[i].unlocked = false;
        }
        for (int i = 0; i < Data.Instance.playerData.correctAnswers + 1; i++) {
            SetCurrentLevel(i);
        }        
    }

	void OnDestroy(){
		//Events.AddScore -= AddScore;
		Events.ReplayArea -= ReplayArea;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddTriviaCount(){
		triviaCount++;
		PlayerPrefs.SetInt ("triviaCount", triviaCount);
	}

	/*void AddScore(){
		if(replay)
			Invoke ("ReplayingLevel", 2f);			
		else
			Invoke ("SetCurrentLevel", 2f);

	}*/

	public void SetLevel(int puntos = 1){
		if (replay)
			ReplayingLevel (puntos);
		else
			SetCurrentLevel (Data.Instance.playerData.correctAnswers);		
	}

	void ReplayingLevel(int puntos){
        Level level = CurrentLevel;
        Debug.Log((levels[playingLevelIndex].localPoints + puntos) + " = " + (0.5 * levels[playingLevelIndex].length));
        if (levels[playingLevelIndex].localPoints+ puntos > 0.5 * levels[playingLevelIndex].length) {
            if (subAreaIndex == 0)
                LevelSubareaChange(playingLevelIndex,puntos);
            else {
                levels[playingLevelIndex].localPoints += puntos;
                if (levels[playingLevelIndex].localPoints >= levels[playingLevelIndex].length) {
                    subAreaIndex = 0;
                    if (playingLevelIndex+1 >= levels.Count) {
                        playingLevelIndex = 0;
                        replay = false;
                        SetAllLevelCompleted();
                    } else {
                        SetLevelCompleted(playingLevelIndex);
                        playingLevelIndex++;
                        if (SceneManager.GetActiveScene().name == "Game") {
                            Data.Instance.levelData.kunakState = KunakStates.area;
                            Data.Instance.LoadScene("Kunak");
                        }
                    }
                }
            }
        } else {
            levels[playingLevelIndex].localPoints+=puntos;            
        }

        Debug.Log("localPoints: " + levels[playingLevelIndex].localPoints);

        /*Events.LevelSelectorUpdate(playingLevelIndex);     

        levels [playingLevelIndex].localPoints++;
		if (levels [playingLevelIndex].localPoints >= levels [playingLevelIndex].length) {
			SetLevelCompleted (playingLevelIndex);
		} else if (levels [playingLevelIndex].localPoints > 0.5 * levels [playingLevelIndex].length) {
			if (subAreaIndex == 0)
				LevelSubareaChange (playingLevelIndex);			
		}*/
	}

	void ReplayArea(int id){
		if (id != currentLevel || (currentLevel==levels.Count && allAreasCompleted)) {
			replay = true;
			replayAreaId = id;
			playingLevelIndex = levels.FindIndex (x => x.id == id);
		} else {
			replay = false;
			playingLevelIndex = currentLevelIndex;
		}
	}

	public void SetCurrentLevel(int correctAnswers){
		if (correctAnswers > 99) {
			if (!allAreasCompleted)
				SetAllLevelCompleted ();
        } else {
			for (int i = 0; i < levels.Count; i++) {
				if (correctAnswers <= levels [i].lastLevelQuestion) {
					if (levels [i].id != currentLevel) {
						if (i > 0) {
							SetLevelCompleted (i - 1);
						}
						UnlockLevel (i);
					} else if (correctAnswers > (levels [i].lastLevelQuestion + 1) - 0.5 * levels [i].length) {
						if (subAreaIndex == 0)
							LevelSubareaChange (i);
						else
							levels [i].localPoints++;
					} else {
                        if(correctAnswers>0)
						levels [i].localPoints++;
					}
					Events.LevelSelectorUpdate (i);
					i = levels.Count;
				}
			}
		}
	}

	void UnlockLevel(int i){
		currentLevel = levels [i].id;
		currentLevelIndex = i;
		playingLevelIndex = i;
		levels [i].unlocked = true;
		//Events.AreaChange (currentLevel);
		subAreaIndex = 0;
		//Events.SubAreaChange (subAreaIndex);
		if(SceneManager.GetActiveScene().name=="Game"){
			Data.Instance.levelData.kunakState = KunakStates.area;
			Data.Instance.LoadScene ("Kunak");			
		}
	}

	void LevelSubareaChange(int i, int puntos=1){
		levels [i].localPoints+=puntos;
		subAreaIndex = 1;
		Events.SubAreaChange (subAreaIndex);
	}

	void SetAllLevelCompleted(){
        if (Data.Instance.esAlumno && Data.Instance.firebaseInitialized) { 
        Firebase.Analytics.FirebaseAnalytics.LogEvent(
          Firebase.Analytics.FirebaseAnalytics.EventTutorialComplete, new Firebase.Analytics.Parameter(Firebase.Analytics.FirebaseAnalytics.ParameterCreativeName,
                "JUEGO TERMINADO&preguntas:"+triviaCount));
        }

        if (!loading)
			Data.Instance.interfaceSfx.WinGameSfx ();
		SetLevelCompleted (currentLevelIndex);
		Events.AllAreasCompleted ();
		allAreasCompleted = true;
		if(SceneManager.GetActiveScene().name=="Game"){
			Data.Instance.levelData.kunakState = KunakStates.allcomplete;
			Data.Instance.LoadScene ("Kunak");			
		}
	}

	void SetLevelCompleted(int index){
        if (Data.Instance.esAlumno && Data.Instance.firebaseInitialized)
        {
            Firebase.Analytics.Parameter[] LevelUpParameters = {
            new Firebase.Analytics.Parameter(
                Firebase.Analytics.FirebaseAnalytics.ParameterLevel, (index+1)),
            new Firebase.Analytics.Parameter(
                Firebase.Analytics.FirebaseAnalytics.ParameterCharacter,"nivel:"+(index+1)+"&preguntas:"+triviaCount)
        };
            Firebase.Analytics.FirebaseAnalytics.LogEvent(
              Firebase.Analytics.FirebaseAnalytics.EventLevelUp,
              LevelUpParameters);
        }

        levels [index].localPoints = 0;
		levels [index].levelCompleted = true;
        subAreaIndex = 0;

        if (replay) {
            //Events.ShowLevelSelector (true);
            Events.LevelSelectorUpdate(index);
        } else {
			Events.LevelSelectorUpdate (index);
		}
	}

	public void AddStars(){
		levels [playingLevelIndex].stars++;
		if(levels [playingLevelIndex].stars>3)
			levels [playingLevelIndex].stars = 3;
		PlayerPrefs.SetInt("stars_"+playingLevelIndex,levels [playingLevelIndex].stars);
		Events.AddStar (playingLevelIndex);
	}

	public Level CurrentLevel{
		get{
			return levels [playingLevelIndex];
		}
	}

    public void ResetRecorrido() {
        PlayerPrefs.DeleteKey("triviaCount");
        for (int i = 0; i < levels.Count; i++) {
            PlayerPrefs.DeleteKey("stars_" + i);
        }
    }
}
