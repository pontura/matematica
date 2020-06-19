using System.Collections.Generic;
using UnityEngine;

public class Module5_D : ModuleData {

    int value_a;
    int value_b;
    int value_c;
    int value_d;
    string textToDecode;

    string[] uPow = { "\u2070", "\u2071", "\u00B2", "\u00B3", "\u2074", "\u2075", "\u2076", "\u2077", "\u2078", "\u2079", "\u2071\u2070" };

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
        if (UnityEngine.Random.value > 0.5f) {
            value_a = UnityEngine.Random.Range(-5, 0);
            value_c = UnityEngine.Random.Range(-5, 0);
            value_d = UnityEngine.Random.Range(-5, 0);
        } else {
            value_a = UnityEngine.Random.Range(1,5);
            value_c = UnityEngine.Random.Range(1,5);
            value_d = UnityEngine.Random.Range(1,5);
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

        SetValue("("+ value_a +"."+value_c+"."+value_d+")"+uPow[value_b]);
        SetValue("(" + value_a + "." + value_c + "." + value_d + ")" + uPow[2*value_b]);
        SetValue("(" + value_a + "." + value_c + "." + value_d + ")" + uPow[value_b+1]);
        
    }
	void SetValue(string number)
	{
        Debug.Log(number);
        //values.Add (Utils.SetFormatedNumber(number));
        values.Add(number);
    }
}