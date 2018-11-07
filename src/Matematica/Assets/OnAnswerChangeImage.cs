using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnAnswerChangeImage : MonoBehaviour {

	public Sprite normalImg,badImg,goodImg;
	public Text text;

	Image image;
	Color textColor;

	void Start()
	{
		image = GetComponent<Image> ();

		textColor = text.color;

		Events.BadAnswer += BadAnswer;
		Events.AddScore += AddScore;
		Events.NextExercise += NextExercise;
	}

	void OnDestroy(){
		Events.BadAnswer -= BadAnswer;
		Events.AddScore -= AddScore;
		Events.NextExercise -= NextExercise;
	}

	void BadAnswer(){
		image.sprite = badImg;
	}

	void AddScore(){
		image.sprite = goodImg;
		text.color = Color.white;
	}

	void NextExercise(){
		image.sprite = normalImg;
		text.color = textColor;
	}
}
