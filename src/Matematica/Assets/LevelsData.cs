using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelsData : MonoBehaviour {

	public List<Level> levels;
	public int currentLevel;
	public int currentLevelIndex;

	public int triviaCount;

	public bool allAreasCompleted;

	public KunakStates kunakState;
	public enum KunakStates{
		inicio,
		area,
		subarea
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
	}

	// Use this for initialization
	void Start () {
		kunakState = KunakStates.inicio;
		Events.AddScore += AddScore;
		triviaCount = PlayerPrefs.GetInt ("triviaCount");
		int count=-1;
		for (int i = 0; i < levels.Count; i++) {
			count += levels [i].length; 
			levels [i].lastLevelQuestion = count;
		}
		for (int i = 0; i < Data.Instance.playerData.correctAnswers+1; i++) {
			SetCurrentLevel (i);
		}
	}

	void OnDestroy(){
		Events.AddScore -= AddScore;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddTriviaCount(){
		triviaCount++;
		PlayerPrefs.SetInt ("triviaCount", triviaCount);
	}

	void AddScore(){
		Invoke ("SetCurrentLevel", 2f);
	}

	public void SetCurrentLevel(){
		SetCurrentLevel (Data.Instance.playerData.correctAnswers);
	}

	public void SetCurrentLevel(int correctAnswers){
		for (int i = 0; i < levels.Count; i++) {
			if (correctAnswers <= levels [i].lastLevelQuestion) {
				if (levels [i].id != currentLevel) {
					if (i > 0) {
						SetLevelCompleted (i - 1);
					}
					UnlockLevel (i);
				} else if (correctAnswers >= (levels [i].lastLevelQuestion + 1) - 0.5 * levels [i].length) {
					LevelAreaChange (i);
				} else {
					levels [i].localPoints++;
				}
				Events.LevelSelectorUpdate (i);
				i = levels.Count;
			} 
		}
	}

	void UnlockLevel(int i){
		currentLevel = levels [i].id;
		currentLevelIndex = i;
		levels [i].unlocked = true;
		Events.AreaChange (currentLevel);
		Events.SubAreaChange (0);
	}

	void LevelAreaChange(int i){
		levels [i].localPoints++;
		Events.SubAreaChange (1);
	}

	void SetLevelCompleted(int index){
		levels [index].localPoints++;
		levels [index].levelCompleted = true;
		Events.LevelSelectorUpdate (index);
	}

	public Level CurrentLevel{
		get{
			return levels [currentLevelIndex];
		}
	}
}
