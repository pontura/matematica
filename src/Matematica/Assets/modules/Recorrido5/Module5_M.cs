using System.Collections.Generic;
using UnityEngine;

public class Module5_M : ModuleData {

    int value_a;
    int value_b;
    string textToDecode;

    string[] uPow = { "\u2070", "\u00B9", "\u00B2", "\u00B3", "\u2074", "\u2075", "\u2076", "\u2077", "\u2078", "\u2079", "\u00B9\u2070" };

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
        value_a = UnityEngine.Random.Range(-10,10);
        value_b = UnityEngine.Random.Range(-10,10);

        if (value_a==-1*value_b) {
            value_b *= -1;
        }

        for (int b = 0; b < arr.Length; b++)
			if (textToDecode [b].ToString () == "a") {				
				newTitle += value_a;
			} else if (textToDecode[b].ToString() == "b") {
                newTitle += value_b;
            } else if (textToDecode[b].ToString() == "c") {
                newTitle += uPow[2];
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

        SetValue(value_a+ uPow[2]+"+"+value_b + uPow[2]+"+"+"2."+ value_a+"."+ value_b);
        SetValue(value_a + uPow[2] + "+" + value_b + uPow[2] );
        SetValue(value_a + uPow[2] + "+" + value_b + uPow[2] + "+" + value_a + "." + value_b);
        
    }
	void SetValue(string number)
	{
        Debug.Log(number);
        //values.Add (Utils.SetFormatedNumber(number));
        values.Add(number);
    }
}
