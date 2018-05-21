using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultButton : MonoBehaviour {

	public Text field;
	public bool correct;

	public void Init(string text, bool correct_)
	{
		field.text = text;
		correct = correct_;
	}

	public void SetResult(){
		if (correct)
			field.color = Color.green;
		else
			field.color = Color.red;

		Button[] buttons = transform.parent.GetComponentsInChildren<Button>();
		foreach (Button b in buttons) {
			b.interactable = false;
		}

		if(correct)
			Events.AddScore ();
		
		Invoke ("NextExercise", 2);
	}

	void NextExercise(){
		Events.NextExercise ();
	}
}
