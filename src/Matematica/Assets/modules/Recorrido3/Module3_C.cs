﻿using System.Collections.Generic;
using UnityEngine;

public class Module3_C : ModuleData {

    int value_a;
    int value_b;
    int value_c;
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
		string newTitle = "\n";
        string par1 = "";
        string par2 = "";
        value_a = UnityEngine.Random.Range(-20, -1);
        if (UnityEngine.Random.value >= 0.5) {
            value_b = UnityEngine.Random.Range(-20, -1);
            value_c = UnityEngine.Random.Range(-20, -1);
            par1 = "(";
            par2 = ")";
        } else {
            value_b = UnityEngine.Random.Range(1,20);
            value_c = UnityEngine.Random.Range(1,20);
        }
          
        for (int b = 0; b < arr.Length; b++)
			if (textToDecode [b].ToString () == "N") {				
				newTitle += "("+value_a+")";
			} else if (textToDecode[b].ToString() == "M") {
                newTitle += par1+value_b+par2;
            } else if (textToDecode[b].ToString() == "O") {
                newTitle += par1+value_c+ par2;
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
		
        SetValue(data[0]);
        SetValue(data[1]);
        SetValue(data[2]);
    }
	void SetValue(string number)
	{
        Debug.Log(number);
		//values.Add (Utils.SetFormatedNumber(number));
        values.Add(number);
    }
}
