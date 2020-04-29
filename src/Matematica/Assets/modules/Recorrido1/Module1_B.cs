using System.Collections.Generic;
using UnityEngine;

public class Module1_B : ModuleData {

	int value_a;
	int value_b;
	int value_number_of_zeros;
	string textToDecode;
    int[] p = { 2, 4, 5, 10, 20 };

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
        value_b = UnityEngine.Random.Range(10, 50);
        for (int b = 0; b < arr.Length; b++)
			if (textToDecode [b].ToString () == "N") {
				value_a = p[UnityEngine.Random.Range (0, p.Length)] * value_b;
				newTitle += value_a;
			} else if (textToDecode [b].ToString () == "M") {				
				newTitle += value_b;
			} else
				newTitle += textToDecode [b].ToString ();			

			title += newTitle;
			SetResults (data.results);
			
			CheckValues ();

	}
	void SetResults(List<string> data)
	{
		results = data;
		values = new List<string> ();
		
        SetValue((100f * value_b / value_a) + " %");
        SetValue ((100f*value_a/value_b) + " %" );        
        SetValue((1f * value_b / value_a) + " %");
	}
	void SetValue(string number)
	{
        Debug.Log(number);
		//values.Add (Utils.SetFormatedNumber(number));
        values.Add(number);
    }
}
