using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelsData : MonoBehaviour {

	public List<Level> levels;
	public int currentLevel;

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
		Invoke ("SetCurrentLevel", 0.1f);
	}

	public void SetCurrentLevel(){
		for (int i = 0; i < levels.Count; i++) {
			Debug.Log (Data.Instance.playerData.correctAnswers + " : " + levels [i].lastLevelQuestion);
			if (Data.Instance.playerData.correctAnswers <= levels [i].lastLevelQuestion) {
				if (levels [i].id != currentLevel) {
					Debug.Log ("ACA1");
					currentLevel = levels [i].id;
					Events.AreaChange (currentLevel);
					Events.SubAreaChange (0);
				}else if(Data.Instance.playerData.correctAnswers>= (levels [i].lastLevelQuestion+1)-0.5*levels[i].length){
					Debug.Log ("ACA2");
					Events.SubAreaChange (1);
				}
				i = levels.Count;
			} 
		}
	}
}
