using System.Collections.Generic;
using UnityEngine;

public class Module5_D : ModuleData {

    int value_a;
    int value_b;
    int value_c;
    int value_d;
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
		string newTitle = "\n";
        if (UnityEngine.Random.value > 0.5f) {
            value_a = UnityEngine.Random.Range(-5, -2);
            value_c = UnityEngine.Random.Range(value_a, -1);
            value_d = UnityEngine.Random.Range(value_c, 0);
        } else {
            value_a = UnityEngine.Random.Range(1,3);
            value_c = UnityEngine.Random.Range(value_a, 4);
            value_d = UnityEngine.Random.Range(value_c, 5);
        }

        value_b = UnityEngine.Random.Range(2, 5);

        for (int b = 0; b < arr.Length; b++)
			if (textToDecode [b].ToString () == "a") {				
				newTitle += value_a;
			} else if (textToDecode[b].ToString() == "b") {
                newTitle += uPow[value_b];
            } else if (textToDecode[b].ToString() == "c") {
                newTitle += value_c;
            } else if (textToDecode[b].ToString() == "d") {
                newTitle += value_d;
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
        string a = ""+value_a;
        if (value_a < 0)
            a = "(" + value_a + ")";
        string c = ""+value_c;
        if (value_c < 0)
            c = "(" + value_c + ")";
        string d = "" + value_d;
        if (value_d < 0)
            d = "(" + value_d + ")";

        SetValue("("+ a +"."+c+"."+d+")"+uPow[value_b]);
        SetValue("(" + a + "." + c + "." + d + ")" + uPow[2*value_b]);
        SetValue("(" + a + "." + c + "." + d + ")" + uPow[value_b+1]);
        
    }
	void SetValue(string number)
	{
        Debug.Log(number);
        //values.Add (Utils.SetFormatedNumber(number));
        values.Add(number);
    }
}