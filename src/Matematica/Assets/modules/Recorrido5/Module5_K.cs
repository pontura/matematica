using System.Collections.Generic;
using UnityEngine;

public class Module5_K : ModuleData {

	int value_a;
	int value_b;
    int value_c;
	string textToDecode;

    string[] uPow = { "\u2070", "\u00B9", "\u00B2", "\u00B3", "\u2074", "\u2075", "\u2076", "\u2077", "\u2078", "\u2079", "\u00B9\u2070", "\u00B9\u00B9", "\u00B9\u00B2", "\u00B9\u00B3", "\u00B9\u2074", "\u00B9\u2075", "\u00B9\u2076" };

    public override void Init(ExercisesData data) 
	{ 
		base.Init (data);

		string titleData = data.title;
		string[] titleDataArr = titleData.Split ("*" [0]);
        title = titleDataArr[0] + "*" + titleDataArr[2];
        textToDecode = titleDataArr [1];
		Calculate ();
	}
	void Calculate()
	{
		string[] arr = new string[textToDecode.Length];
		string newTitle = "";
        value_a = UnityEngine.Random.Range(-2, -10);
        value_b = UnityEngine.Random.Range(2, 5);
        value_c = UnityEngine.Random.Range(2, 5);

        while (((value_c *  value_b) == (value_c + value_b))||((value_c * value_b)==Mathf.Pow(value_b,value_c))) {
            value_c = UnityEngine.Random.Range(2, 5);
        }
        

        for (int b = 0; b < arr.Length; b++)
            if (textToDecode[b].ToString() == "A") {                
                newTitle += " <size=18>(" + value_a + ")"+ uPow[value_b] + "</size>";
            } else if (textToDecode[b].ToString() == "C") {
                newTitle += uPow[value_c];
            } else {
                newTitle += textToDecode[b].ToString();
            }
        Debug.Log(newTitle);
        //newTitle2 = newTitle2.Replace("+", "<color=#8A00C9>+</color>");
        title = title.Replace("*", newTitle);
        Debug.Log(title);
        SetResults (data.results);
			
		CheckValues ();

	}
	void SetResults(List<string> data)
	{
		results = data;
		values = new List<string> ();

        SetValue("" + (Mathf.Pow(value_a,value_b*value_c)));
        SetValue("" + (Mathf.Pow(value_a, value_b + value_c)));
        SetValue("" + (Mathf.Pow(value_a, Mathf.Pow(value_b,value_c))));
    }
	void SetValue(string number)
	{
        Debug.Log(number);
		//values.Add (Utils.SetFormatedNumber(number));
        values.Add(number);
    }
}
