using System.Collections.Generic;
using UnityEngine;

public class Module5_G : ModuleData {

    int value_a;
    int value_b;
    int value_c;
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
        if (UnityEngine.Random.value > 0.5f) {
            value_b = UnityEngine.Random.Range(-5, -1);
            value_c = UnityEngine.Random.Range(-5, -1);
        } else {
            value_b = UnityEngine.Random.Range(2, 5);
            value_c = UnityEngine.Random.Range(2,5);
        }

        value_a = value_c * UnityEngine.Random.Range(2, 5);

        for (int b = 0; b < arr.Length; b++)
			if (textToDecode [b].ToString () == "a") {				
				newTitle += value_a;
			} else if (textToDecode[b].ToString() == "b") {
                if (value_b < 0) {
                    newTitle += "\u207b"+uPow[Mathf.Abs(value_b)];
                } else {
                    newTitle += uPow[value_b];
                }
            } else if (textToDecode[b].ToString() == "c") {
                newTitle += value_c;
            } else
                newTitle += textToDecode [b].ToString ();			

			title = title.Replace("#",newTitle);
			SetResults (data.results);
			
			CheckValues ();

	}
    void SetResults(List<string> data) {
        results = data;
        values = new List<string>();

        if (value_b < 0) { 
            SetValue("(" + value_a + ":" + value_c + ")\u207b" + uPow[Mathf.Abs(value_b)]);
            SetValue("(" + value_a + ":" + value_c + ")\u207b" + uPow[Mathf.Abs(2 * value_b)]);
        } else {
            SetValue("(" + value_a + ":" + value_c + ")" + uPow[value_b]);
            SetValue("(" + value_a + ":" + value_c + ")" + uPow[2 * value_b]);
        }
        SetValue("(" + value_a + ":" + value_c + ")" + uPow[0]);

    }
	void SetValue(string number)
	{
        Debug.Log(number);
        //values.Add (Utils.SetFormatedNumber(number));
        values.Add(number);
    }
}