using System.Collections.Generic;
using UnityEngine;

public class Module6_J : ModuleData {

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
        do {
            value_a = UnityEngine.Random.Range(-10, 10);
        } while (value_a == 0);

        do {
            value_b = UnityEngine.Random.Range(-10, 10);
        } while (value_b == 0);

        for (int b = 0; b < arr.Length; b++)
			if (textToDecode [b].ToString () == "a") {				
				newTitle += value_a;
			} else if (textToDecode[b].ToString() == "b") {
                newTitle += value_b;
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

        SetValue("Sólo una solución");
        SetValue("Más de una solución");
        SetValue("Ninguna solución");
        
    }
	void SetValue(string number)
	{
        Debug.Log(number);        
        //values.Add (Utils.SetFormatedNumber(number));
        values.Add(number);
    }
}
