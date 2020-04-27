using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

	public int correctAnswers;
    public int mode;

	// Use this for initialization
	void Awake(){
		correctAnswers = PlayerPrefs.GetInt ("correctAnswers");
        mode = PlayerPrefs.GetInt("mode",-1);
    }

	void Start () {		
		Events.AddScore += AddScore;
	}

	void OnDestroy(){
		Events.AddScore -= AddScore;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void AddScore(){
		if (!Data.Instance.levelData.replay) {
			correctAnswers++;
			PlayerPrefs.SetInt ("correctAnswers", correctAnswers);
		}
	}

	public void AddScore(int add){
		if (!Data.Instance.levelData.replay) {
			correctAnswers+=add;
			PlayerPrefs.SetInt ("correctAnswers", correctAnswers);
		}
	}

    public void SetMode(int m) {
        mode = m;
        PlayerPrefs.SetInt("mode", mode);
    }
}
