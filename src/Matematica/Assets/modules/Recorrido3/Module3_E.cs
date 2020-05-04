using System.Collections.Generic;
using UnityEngine;

public class Module3_E : ModuleData {

    int value_a;
    int value_b;
    int value_c;
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
        value_a = UnityEngine.Random.Range(-20,-1);
        value_b = UnityEngine.Random.Range(-20, -1);
        value_c = UnityEngine.Random.Range(-20, -1);        
          
        for (int b = 0; b < arr.Length; b++)
			if (textToDecode [b].ToString () == "N") {				
				newTitle += value_a;			
			} else if (textToDecode[b].ToString() == "M") {
                newTitle += value_b;
            } else if (textToDecode[b].ToString() == "P") {
                newTitle += value_c;
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
		
        SetValue(data[0]);
        SetValue(data[1]);
        SetValue(data[2]);
    }
	void SetValue(string number)
	{
        Debug.Log(number);
		//values.Add (Utils.SetFormatedNumber(number));
        values.Add(number);
    }
}
