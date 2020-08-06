using System.Collections.Generic;
using UnityEngine;

public class Module6_G : ModuleData {

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
        value_b = 2*UnityEngine.Random.Range(1, 5);

        for (int b = 0; b < arr.Length; b++)
			if (textToDecode [b].ToString () == "a") {
                if(value_a<0)
				    newTitle += "("+value_a+")";
                else
                    newTitle += value_a;
            } else if (textToDecode[b].ToString() == "b") {
                newTitle += uPow[value_b];
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

        if (value_a == 0) {
            SetValue("1 solución");
            SetValue("2 soluciones");
            SetValue("Ninguna solución");
        }else if(value_a < 0) {            
            SetValue("2 soluciones");
            SetValue("1 solución");
            SetValue("Ninguna solución");
        } else {
            SetValue("Ninguna solución");
            SetValue("2 soluciones");
            SetValue("1 solución");
        }

        
    }
	void SetValue(string number)
	{        
        Debug.Log(number);
		//values.Add (Utils.SetFormatedNumber(number));
        values.Add(number);
    }
}
