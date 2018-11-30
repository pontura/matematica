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
		triviaCount = PlayerPrefs.GetInt ("triviaCount");
		int count=-1;
		for (int i = 0; i < levels.Count; i++) {
			count += levels [i].length; 
			levels [i].lastLevelQuestion = count;
			levels[i].stars = PlayerPrefs.GetInt("stars_"+i);
		}
		for (int i = 0; i < Data.Instance.playerData.correctAnswers+1; i++) {
			SetCurrentLevel (i);
		}

		loading = false;
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

	public void SetCurrentLevel(){
		if (replay)
			ReplayingLevel ();
		else
			SetCurrentLevel (Data.Instance.playerData.correctAnswers);		
	}

	void ReplayingLevel(){
		levels [playingLevelIndex].localPoints++;
		if (levels [playingLevelIndex].localPoints >= levels [playingLevelIndex].length) {
			SetLevelCompleted (playingLevelIndex);
		} else if (levels [playingLevelIndex].localPoints > (levels [playingLevelIndex].lastLevelQuestion + 1) - 0.5 * levels [playingLevelIndex].length) {
			if (subAreaIndex == 0)
				LevelSubareaChange (playingLevelIndex);			
		}
	}

	void ReplayArea(int id){
		if (id != currentLevel) {
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

	void LevelSubareaChange(int i){
		levels [i].localPoints++;
		subAreaIndex = 1;
		Events.SubAreaChange (subAreaIndex);
	}

	void SetAllLevelCompleted(){
		if(!loading)
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
		levels [index].localPoints = 0;
		levels [index].levelCompleted = true;
		if (replay) {
			Events.ShowLevelSelector (true);
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
}
