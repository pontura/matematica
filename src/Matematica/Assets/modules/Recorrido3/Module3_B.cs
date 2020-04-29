using System.Collections.Generic;
using UnityEngine;

public class Module3_B : ModuleData {

	int value_a;
	int value_number_of_zeros;
	string textToDecode;

	public override void Init(ExercisesData data) 
	{ 
		base.Init (data);

		string titleData = data.title;
		string[] titleDataArr = titleData.Split ("#" [0]);
		title =  titleDataArr [0] + "#" + titleDataArr[2];
		textToDecode = titleDataArr [1];
		Calculate ();
	}
	void Calculate()
	{
		string[] arr = new string[textToDecode.Length];
		string newTitle = "";
        value_a = UnityEngine.Random.Range(-20, 20);
        for (int b = 0; b < arr.Length; b++)
			if (textToDecode [b].ToString () == "N") {				
				newTitle += value_a;			
			} else
				newTitle += textToDecode [b].ToString ();			

			title = title.Replace("#",newTitle);
			SetResults (data.results);
			
			CheckValues ();

	}
	void SetResults(List<string> data)
	{
		results = data;
		values = new List<string> ();
		
        SetValue("X ≤ "+ value_a);
        SetValue("X < " + value_a);
        SetValue("X > " + value_a);
    }
	void SetValue(string number)
	{
        Debug.Log(number);
		//values.Add (Utils.SetFormatedNumber(number));
        values.Add(number);
    }
}
