using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultButton : MonoBehaviour {

	public Text field;
	public bool correct;
	public Sprite normalImg,goodImg,badImg;
	public AudioClip correcto, incorrecto;

	Image image;
	AudioSource audiosource;

	void Start(){
		image = GetComponentInChildren<Image> ();
		audiosource = GetComponent<AudioSource> ();
	}

	public void Init(string text, bool correct_)
	{
		field.text = text;
		correct = correct_;
	}

	public void SetResult(){
		if (correct) {
			field.color = Color.white;
			image.sprite = goodImg;
			audiosource.clip = correcto;
			audiosource.Play ();
		} else {
			field.color = Color.yellow;
			image.sprite = badImg;
			audiosource.clip = incorrecto;
			audiosource.Play ();
		}

		Button[] buttons = transform.parent.GetComponentsInChildren<Button>();
		foreach (Button b in buttons) {
			b.interactable = false;
		}

		if (correct) {
			Events.AddScore ();
		} else {
			Events.BadAnswer ();
			Invoke ("NextExercise", 2);
		}	

	}

	void NextExercise(){
		Events.NextExercise ();
	}
}
