using System.Collections.Generic;
using UnityEngine;

public class Module7_M : ModuleData {

    int value_a;
    string textToDecode;

	public override void Init(ExercisesData data) 
	{ 
		base.Init (data);

        /*string titleData = data.title;
		string[] titleDataArr = titleData.Split ("#" [0]);
		title =  titleDataArr [0] + "#" + titleDataArr[2];
		textToDecode = titleDataArr [1];
		Calculate ();*/
        title = data.title;
        value_a = UnityEngine.Random.Range(3, 20);
        SetResults(data.results);
    }
	void Calculate()
	{
		string[] arr = new string[textToDecode.Length];
		string newTitle = "";
        value_a = UnityEngine.Random.Range(3,20);

        for (int b = 0; b < arr.Length; b++)
			if (textToDecode [b].ToString () == "A") {				
				newTitle += (value_a);			
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

        SetValue(value_a + ", " + value_a + " y " + value_a);
        SetValue(value_a + ", " + (value_a + 1) + " y " + (value_a + 2));
        SetValue(value_a+ ", "+ value_a + " y "+ (value_a+2));                
    }
	void SetValue(string number)
	{
        Debug.Log(number);
		//values.Add (Utils.SetFormatedNumber(number));
        values.Add(number);
    }
}
