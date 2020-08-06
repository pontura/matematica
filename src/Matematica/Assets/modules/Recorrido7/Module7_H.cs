using System.Collections.Generic;
using UnityEngine;

public class Module7_H : ModuleData {

    int value_a;
    int value_b;
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
        value_a = UnityEngine.Random.Range(90,140);
        value_b = UnityEngine.Random.Range(10,70);

        for (int b = 0; b < arr.Length; b++)
			if (textToDecode [b].ToString () == "A") {				
				newTitle += (value_a);			
			} else if (textToDecode[b].ToString() == "B") {
                newTitle += (value_b);
            }else
            newTitle += textToDecode [b].ToString ();			

			title = title.Replace("#",newTitle);
			SetResults (data.results);
			
			CheckValues ();

	}
	void SetResults(List<string> data)
	{
		results = data;
		values = new List<string> ();

        SetValue((360 - 2*value_a - value_b) + "°");
        SetValue((360 - value_a - value_b) + "°");
        SetValue((180 - 2 * value_a - value_b) + "°");
        
    }
	void SetValue(string number)
	{
        Debug.Log(number);
		//values.Add (Utils.SetFormatedNumber(number));
        values.Add(number);
    }
}
