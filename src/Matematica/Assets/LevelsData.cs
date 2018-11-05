using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelsData : MonoBehaviour {

	public List<Level> levels;
	public int currentLevel;
	int currentLevelIndex;

	[Serializable]
	public class Level
	{
		public int id;
		public int length;
		public int lastLevelQuestion;
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
					currentLevel = levels [i].id;
					currentLevelIndex = i;
					Events.AreaChange (currentLevel);
					Events.SubAreaChange (0);
				}else if(Data.Instance.playerData.correctAnswers>= (levels [i].lastLevelQuestion+1)-0.5*levels[i].length){
					Events.SubAreaChange (1);
				}
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
