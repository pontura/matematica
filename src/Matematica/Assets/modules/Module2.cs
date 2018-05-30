using System.Collections.Generic;
using UnityEngine;

public class Module2 : ModuleData {

	int value_a;
	int value_b;
	int value_c;
	string textToDecode;
	public override void Init(ExercisesData data) 
	{ 
		base.Init (data);

		string titleData = data.title;
		string[] titleDataArr = titleData.Split ("#" [0]);
		title =  titleDataArr [0];
		textToDecode = titleDataArr [1];
		Calculate ();
	}
	void Calculate()
	{
		string[] arr = new string[textToDecode.Length];
		string newTitle = "";
		for (int b = 0; b < arr.Length; b++)
			if (textToDecode [b].ToString () == "a") {
				value_a = UnityEngine.Random.Range (1, 9);
				newTitle += value_a;
			} else if (textToDecode [b].ToString () == "b") {
				value_b = UnityEngine.Random.Range (1, 9);
				newTitle += value_b;
			} else if (textToDecode [b].ToString () == "c") {
				value_c = UnityEngine.Random.Range (2, 9);
				newTitle += value_c;
			} else
				newTitle += textToDecode [b].ToString ();
		if (value_a * 10 <= value_b * value_c) {
			Debug.Log ("Recalculate porque a: " + (value_a*10) + " es menor que BxC (" + value_b + "x" + value_c + ")");
			Calculate ();
		} else {
			title += newTitle;
			SetResults (data.results);
		}
	}
	void SetResults(List<string> data)
	{
		results = data;
		values = new List<string> ();

		//"a0-(bxc)", 
		//"bxc", 
		//"(a0-b)xc"

		SetValue ((value_a*10) - (value_b * value_c));
		SetValue (value_b * value_c);
		SetValue (((value_a*10) - value_b) * value_c);
	}
	void SetValue(int calculate)
	{
		values.Add (calculate.ToString ());
	}
}
