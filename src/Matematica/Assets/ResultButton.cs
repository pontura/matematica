using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultButton : MonoBehaviour {

	public Text field;

	public void Init(string text)
	{
		field.text = text;
	}
}
