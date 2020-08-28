using System.Collections.Generic;
using UnityEngine;

public class Module4_F : ModuleData {

    int value_c;
    int value_d;
	string textToDecode;

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
        string newTitle2 = "";
        string newTitle3 = "";        
        value_c = UnityEngine.Random.Range(-3, -9);
        value_d = UnityEngine.Random.Range(2, Mathf.Abs(value_c));

        for (int b = 0; b < arr.Length; b++)
            if (textToDecode[b].ToString() == "A") {
                newTitle += " <size=28><u>-" + Mathf.Abs(value_c) + " </u></size>";
                newTitle2 += " </color><size=28><u>  1  </u></size><color=#8A00C9>";
                newTitle3 += " </color><size=28> " + value_d + " </size><color=#8A00C9>";
            } else {
                newTitle += textToDecode[b].ToString();
                newTitle2 += textToDecode[b].ToString();
                newTitle3 += textToDecode[b].ToString();
            }
        Debug.Log(newTitle);
        Debug.Log(newTitle2);
        string title2 = "<color=#8A00C9>" +title+ "</color>";
        title = title.Replace("*", newTitle);
        Debug.Log(title);
        Events.SetTitleDenom(title2.Replace("*", newTitle2));
        Events.SetTitleDenomDown(title2.Replace("*", newTitle3));
        Debug.Log(title2.Replace("*", newTitle2));
        SetResults (data.results);
			
		CheckValues ();

	}
	void SetResults(List<string> data)
	{
		results = data;
		values = new List<string> ();
        if (value_c * value_d > 0) {
            SetValue("" + ((1.0f * Mathf.Abs(value_d)) + "/" + Mathf.Abs(value_c)));
            SetValue("" + ((1.0f * Mathf.Abs(value_c)) + "/" + Mathf.Abs(value_d)));
            SetValue("" + (1.0f + "/" + (value_d * value_c)));
        } else {
            SetValue("-" + ((1.0f * Mathf.Abs(value_d)) + "/" + Mathf.Abs(value_c)));
            SetValue("-" + ((1.0f * Mathf.Abs(value_c)) + "/" + Mathf.Abs(value_d)));
            SetValue("-" + (1.0f + "/" + Mathf.Abs(value_d * value_c)));
        }
    }
	void SetValue(string number)
	{
        Debug.Log(number);
		//values.Add (Utils.SetFormatedNumber(number));
        values.Add(number);
    }
}
