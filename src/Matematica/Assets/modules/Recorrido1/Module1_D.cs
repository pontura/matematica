using System.Collections.Generic;
using UnityEngine;

public class Module1_D : ModuleData {

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
        value_a = UnityEngine.Random.Range(3, 15);
        value_d = UnityEngine.Random.Range(3, 15);
        value_b = UnityEngine.Random.Range(2, value_d);
        value_c = UnityEngine.Random.Range(2, value_a);
        
        for (int b = 0; b < arr.Length; b++)
            if (textToDecode[b].ToString() == "A") {                
                newTitle += "\n<size=28> " + value_b + "  </size>";
                newTitle2 += "\n</color><size=28><u>  " + value_a + "  </u></size>";
            } else if (textToDecode[b].ToString() == "C") {
                newTitle += "<size=28>  " + value_d + " </size>";
                newTitle2 += "<size=28><u>  " + value_c + "  </u></size><color=#8A00C9>";
            } else {
                newTitle += textToDecode[b].ToString();
                newTitle2 += textToDecode[b].ToString();
            }
        Debug.Log(newTitle);
        Debug.Log(newTitle2);
        newTitle2 = newTitle2.Replace("-", "<color=#8A00C9><size=55>-</size></color>");
        newTitle = newTitle.Replace("-", "<size=55>-</size>");
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

        SetValue("" + ((1.0f*(value_a * value_d)-(value_b*value_c))+"/"+(value_b * value_d)));
        SetValue(""+(1.0f*(value_a - value_c) + "/" + (value_b - value_d)));
        SetValue("" + (1.0f * (value_a - value_c) + "/" + (value_b * value_d)));
    }
	void SetValue(string number)
	{
        Debug.Log(number);
		//values.Add (Utils.SetFormatedNumber(number));
        values.Add(number);
    }
}
