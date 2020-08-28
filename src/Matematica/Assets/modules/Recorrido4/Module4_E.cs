﻿using System.Collections.Generic;
using UnityEngine;

public class Module4_E : ModuleData {

	int value_a;
	int value_b;
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
        string newTitle4 = "";
        value_a = UnityEngine.Random.Range(-5, -9);
        value_b = UnityEngine.Random.Range(4, Mathf.Abs(value_a));
        value_c = UnityEngine.Random.Range(-3, -1*value_b);
        value_d = UnityEngine.Random.Range(2, Mathf.Abs(value_c));
                
        for (int b = 0; b < arr.Length; b++)
            if (textToDecode[b].ToString() == "A") {                
                newTitle += " <size=28><u>-" + Mathf.Abs(value_c) + " </u></size>";
                newTitle2 += " </color><size=28><u>-" + Mathf.Abs(value_a) + " </u></size><color=#8A00C9>";
                newTitle3 += " </color><size=28><u>  " + value_b + "  </u></size><color=#8A00C9>";
                newTitle4 += " </color><size=28> " + value_d + " </size><color=#8A00C9>";
            } else {
                newTitle += textToDecode[b].ToString();
                newTitle2 += textToDecode[b].ToString();
                newTitle3 += textToDecode[b].ToString();
                newTitle4 += textToDecode[b].ToString();
            }
        Debug.Log(newTitle);
        Debug.Log(newTitle2);
        string title2 = "<color=#8A00C9>" +title+ "</color>";
        title = title.Replace("*", newTitle);
        Debug.Log(title);
        Events.SetTitleDenomUp(title2.Replace("*", newTitle2));
        Events.SetTitleDenom(title2.Replace("*", newTitle3));
        Events.SetTitleDenomDown(title2.Replace("*", newTitle4));
        Debug.Log(title2.Replace("*", newTitle2));
        SetResults (data.results);
			
		CheckValues ();

	}
	void SetResults(List<string> data)
	{
		results = data;
		values = new List<string> ();
        if((value_a * value_d) * (value_b * value_c)>0)
            SetValue("" + ((1.0f * Mathf.Abs(value_a * value_d)) +"/"+ Mathf.Abs(value_b * value_c)));
        else
            SetValue("-" + ((1.0f * Mathf.Abs(value_a * value_d)) + "/" + Mathf.Abs(value_b * value_c)));

        if ((value_a * value_c) * (value_b * value_d) > 0)
            SetValue("" + ((1.0f* Mathf.Abs(value_a * value_c)) + "/" + Mathf.Abs(value_b * value_d)));
        else
            SetValue("-" + ((1.0f * Mathf.Abs(value_a * value_c)) + "/" + Mathf.Abs(value_b * value_d)));

        if ((value_a * value_b) * (value_d * value_c) > 0)
            SetValue("" + ((1.0f * Mathf.Abs(value_a * value_b)) + "/" + Mathf.Abs(value_d * value_c)));
        else
            SetValue("-" + ((1.0f * Mathf.Abs(value_a * value_b)) + "/" + Mathf.Abs(value_d * value_c)));
    }
	void SetValue(string number)
	{
        Debug.Log(number);
		//values.Add (Utils.SetFormatedNumber(number));
        values.Add(number);
    }
}
