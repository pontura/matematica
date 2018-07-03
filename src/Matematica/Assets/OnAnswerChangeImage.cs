using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnAnswerChangeImage : MonoBehaviour {

	public Sprite normalImg,badImg,goodImg;

	Image image;

	void Start()
	{
		image = GetComponent<Image> ();

		Events.BadAnswer += BadAnswer;
		Events.AddScore += AddScore;
		Events.NextExercise += NextExercise;
	}

	void OnDestroy(){
		Events.BadAnswer += BadAnswer;
		Events.AddScore -= AddScore;
		Events.NextExercise -= NextExercise;
	}

	void BadAnswer(){
		image.sprite = badImg;
	}

	void AddScore(){
		image.sprite = goodImg;
	}

	void NextExercise(){
		image.sprite = normalImg;
	}
}
