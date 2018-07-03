using System.Collections.Generic;
using UnityEngine;

public class Module7 : ModuleData {

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

		string[] arr = new string[textToDecode.Length];
		for (int b = 0; b < arr.Length; b++)
			if (textToDecode [b].ToString () == "a") {
				value_a = UnityEngine.Random.Range (1, 9);
				title += value_a;
			} else if (textToDecode [b].ToString () == "b") {
				value_b = UnityEngine.Random.Range (1, 9);
				title += value_b;
			} else if (textToDecode [b].ToString () == "c") {
				value_c = UnityEngine.Random.Range (2, 9);
				title += value_c;
			} else
				title += textToDecode [b].ToString ();

		SetResults (data.results);
		CheckValues ();
	}
	void SetResults(List<string> data)
	{
		results = data;
		values = new List<string> ();
		SetValue (value_a + (value_b * value_c));
		SetValue ((value_a + value_b) * value_c);
		SetValue (value_b * value_c);
	}
	void SetValue(int calculate)
	{
		values.Add (calculate.ToString ());
	}
}
