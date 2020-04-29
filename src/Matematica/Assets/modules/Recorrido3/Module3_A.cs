using System.Collections.Generic;
using UnityEngine;

public class Module3_A : ModuleData {

	int value_a;
	int value_b;
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
        value_a = UnityEngine.Random.Range(-19, 20);
        value_b = UnityEngine.Random.Range(-20, value_a);
        for (int b = 0; b < arr.Length; b++)
			if (textToDecode [b].ToString () == "N") {				
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
		
        SetValue((value_a - value_b)+"");
        SetValue((value_b - value_a) + "");
        SetValue((value_a + value_b) + "");
    }
	void SetValue(string number)
	{
        Debug.Log(number);
		//values.Add (Utils.SetFormatedNumber(number));
        values.Add(number);
    }
}
