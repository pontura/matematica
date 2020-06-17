using System.Collections.Generic;
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

        value_a = UnityEngine.Random.Range(5, 9);
        value_b = UnityEngine.Random.Range(4, value_a);
        value_c = UnityEngine.Random.Range(3, value_b);
        value_d = UnityEngine.Random.Range(2, value_c);

        for (int b = 0; b < arr.Length; b++)
            if (textToDecode[b].ToString() == "A") {                
                newTitle += "<size=18>\u0305\u0305" + value_c + "\u0305\u0305</size>";
                newTitle2 += "</color><size=18>" + value_a + "</size><color=#8A00C9>";
                newTitle3 += "</color><size=18>\u0305" + value_b + "\u0305</size><color=#8A00C9>";
                newTitle4 += "</color><size=18>\u0305" + value_d + "\u0305</size><color=#8A00C9>";
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

        SetValue("" + ((1.0f * (value_a * value_d)) / (value_b * value_c)));
        SetValue("" + ((1.0f*(value_a * value_c)) / (value_b * value_d)));        
        SetValue("" + ((1.0f * (value_a * value_b)) / (value_d * value_c)));
    }
	void SetValue(string number)
	{
        Debug.Log(number);
		//values.Add (Utils.SetFormatedNumber(number));
        values.Add(number);
    }
}
