using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelsData : MonoBehaviour {

	public List<Level> levels;
	public int currentLevel;
	public int currentLevelIndex;

	[Serializable]
	public class Level
	{
		public int id;
		public int length;
		public int localPoints;
		public int lastLevelQuestion;
		public bool unlocked;
	}

	// Use this for initialization
	void Start () {
		Events.AddScore += AddScore;
		int count=-1;
		for (int i = 0; i < levels.Count; i++) {
			count += levels [i].length; 
			levels [i].lastLevelQuestion = count;
		}
		SetCurrentLevel ();
	}

	void OnDestroy(){
		Events.AddScore -= AddScore;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void AddScore(){
		Invoke ("SetCurrentLevel", 2f);
	}

	public void SetCurrentLevel(){
		for (int i = 0; i < levels.Count; i++) {
			if (Data.Instance.playerData.correctAnswers <= levels [i].lastLevelQuestion) {
				if (levels [i].id != currentLevel) {
					if (i > 0) {
						levels [i - 1].localPoints++;
						Events.LevelSelectorUpdate (i-1);
					}
					currentLevel = levels [i].id;
					currentLevelIndex = i;
					levels [i].unlocked = true;
					Events.AreaChange (currentLevel);
					Events.SubAreaChange (0);
				} else if (Data.Instance.playerData.correctAnswers >= (levels [i].lastLevelQuestion + 1) - 0.5 * levels [i].length) {
					levels [i].localPoints++;
					Events.SubAreaChange (1);
				} else {
					levels [i].localPoints++;
				}
				Debug.Log ("a");
				Events.LevelSelectorUpdate (i);
				i = levels.Count;
			} 
		}
	}

	public Level CurrentLevel{
		get{
			return levels [currentLevelIndex];
		}
	}
}
