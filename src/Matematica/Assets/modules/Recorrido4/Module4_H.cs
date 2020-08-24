using System.Collections.Generic;
using UnityEngine;

public class Module4_H : ModuleData {

	int value_a;
	int value_b;
    int value_c;
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
        value_a = UnityEngine.Random.Range(1, 9);
        value_b = UnityEngine.Random.Range(0, 9);
        value_c = UnityEngine.Random.Range(1, 9);
        for (int b = 0; b < arr.Length; b++)
            if (textToDecode[b].ToString() == "A") {                
                newTitle += "\n<size=55>-</size> <size=28> 100 </size> ";
                newTitle2 += "\n<size=55>-</size> </color><size=28><u> " + value_a + value_b +value_c + " </u></size><color=#8A00C9> ";
            } else {
                newTitle += textToDecode[b].ToString();
                newTitle2 += textToDecode[b].ToString();
            }
        Debug.Log(newTitle);
        Debug.Log(newTitle2);        
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

        SetValue("-" + value_a +","+value_b+value_c);
        SetValue("" + value_a + "," + value_b + value_c);
        SetValue("0," + value_a + value_b + value_c);
    }
	void SetValue(string number)
	{
        Debug.Log(number);
		//values.Add (Utils.SetFormatedNumber(number));
        values.Add(number);
    }
}
