﻿using System.Collections.Generic;
using UnityEngine;

public class Module5_I : ModuleData {

	int value_a;
	int value_b;
    int value_c;
    int value_d;
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
        string newTitle2 = "";
        if (UnityEngine.Random.value > 0.5f) {
            value_a = UnityEngine.Random.Range(-5, -1);
            value_c = UnityEngine.Random.Range(-5, 0);
            value_d = UnityEngine.Random.Range(-5, 0);
        } else {
            value_a = UnityEngine.Random.Range(2, 6);
            value_c = UnityEngine.Random.Range(1, 5);
            value_d = UnityEngine.Random.Range(1, 5);
        }
        value_b = UnityEngine.Random.Range(2, 8);

        //while (value_d/(value_d-1)==value_c) {
        while ((value_c *  (value_d - 1)) == value_d) {
            if (UnityEngine.Random.value > 0.5f) {
                value_d = UnityEngine.Random.Range(-5, 0);
            } else {
                value_d = UnityEngine.Random.Range(1, 5);
            }
        }
        

        for (int b = 0; b < arr.Length; b++)
            if (textToDecode[b].ToString() == "A") {                
                newTitle += " <size=18><color=#8A00C9></color> \u0305" + value_b + "\u0305 </size>";
                newTitle2 += "</color><size=18>   " + value_a + " </size><color=#8A00C9>";
            } else if (textToDecode[b].ToString() == "B") {
                newTitle += " <size=18><color=#8A00C9></color> \u0305" + value_b + "\u0305 </size>";
                newTitle2 += "</color><size=18>   " + value_a + " </size><color=#8A00C9>";
            } else if (textToDecode[b].ToString() == "C") {
                if (value_c < 0) {
                    newTitle += "\u207b" + uPow[Mathf.Abs(value_c)];
                    newTitle2 += "\u207b" + uPow[Mathf.Abs(value_c)];
                } else {
                    newTitle += uPow[value_c];
                    newTitle2 += uPow[value_c];
                }
            } else if (textToDecode[b].ToString() == "D") {
                if (value_d < 0) {
                    newTitle += "\u207b" + uPow[Mathf.Abs(value_d)];
                    newTitle2 += "\u207b" + uPow[Mathf.Abs(value_d)];
                } else {
                    newTitle += uPow[value_d];
                    newTitle2 += uPow[value_d];
                }
            } else {
                newTitle += textToDecode[b].ToString();
                newTitle2 += textToDecode[b].ToString();
            }
        Debug.Log(newTitle);
        Debug.Log(newTitle2);
        //newTitle2 = newTitle2.Replace("+", "<color=#8A00C9>+</color>");
        string title2 = "<color=#8A00C9>" +title+ "</color>";
        title = title.Replace("*", newTitle);
        Debug.Log(title);
        Events.SetTitleDenom(title2.Replace("*", newTitle2));
        Debug.Log(title2.Replace("*", newTitle2));
        SetResults (data.results);
			
		CheckValues ();

	}
	void SetResults(List<string> data)
	{
		results = data;
		values = new List<string> ();

        if (value_c + value_d < 0)
            SetValue("(" + value_a + "/" + value_b + ")\u207b" + uPow[Mathf.Abs(value_c + value_d)]);
        else
            SetValue("(" + value_a + "/" + value_b + ")" + uPow[value_c + value_d]);
        if (value_c - value_d<0)
            SetValue("(" + value_a + "/" + value_b + ")\u207b" + uPow[Mathf.Abs(value_c - value_d)]);
        else
            SetValue("(" + value_a + "/" + value_b + ")" + uPow[value_c - value_d]);

        SetValue("(" + value_a + "/" + value_b + ")" + uPow[value_c * value_d]);
    }
	void SetValue(string number)
	{
        Debug.Log(number);
		//values.Add (Utils.SetFormatedNumber(number));
        values.Add(number);
    }
}