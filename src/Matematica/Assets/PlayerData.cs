using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

	public int correctAnswers;

	// Use this for initialization
	void Awake(){
		correctAnswers = PlayerPrefs.GetInt ("correctAnswers");
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
		correctAnswers++;
		PlayerPrefs.SetInt ("correctAnswers", correctAnswers);
	}
}
