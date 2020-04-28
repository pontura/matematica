using System.Collections.Generic;
using UnityEngine;

public class Module10 : ModuleData {

	int value_a;
	int value_b;
	int value_c;
	string textToDecode;

	public override void Init(ExercisesData data) 
	{ 
		base.Init (data);

		title =  data.title;
		Calculate ();
	}
	void Calculate()
	{
		/*string[] arr = new string[textToDecode.Length];
		string newTitle = "";
		for (int b = 0; b < arr.Length; b++)
			if (textToDecode [b].ToString () == "a") {
				value_a = UnityEngine.Random.Range (1, 9);
				newTitle += value_a;
			} else if (textToDecode [b].ToString () == "b") {
				value_b = UnityEngine.Random.Range (1, 9);
				newTitle += value_b;
			} else if (textToDecode [b].ToString () == "c") {
				int rand = UnityEngine.Random.Range (0, 10);
				if (rand > 5)
					value_c = 5;
				else
					value_c = 2;
				newTitle += value_c;
			} else
				newTitle += textToDecode [b].ToString ();

			title += newTitle;*/

		value_a = UnityEngine.Random.Range (1100, 2000);
		value_b = UnityEngine.Random.Range (100, 200);
		value_c = UnityEngine.Random.Range (500, 700);

		title = title.Replace ("*X", "" + value_a);
		title = title.Replace ("*Y", "" + value_b);
		title = title.Replace ("*Z", "" + value_c);

		SetResults (data.results);
		//CheckValues ();

	}
	void SetResults(List<string> data)
	{
		results = data;
		values = new List<string> ();

		foreach(string ss in data){
			string s = ss;
			s = s.Replace ("*X", "" + value_a);
			s = s.Replace ("*Y", "" + value_b);
			s = s.Replace ("*Z", "" + value_c);	
			values.Add (s);
		}
	}
}

