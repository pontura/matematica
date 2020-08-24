using System.Collections.Generic;
using UnityEngine;

public class Module5_B : ModuleData {

	int value_a;
	int value_b;
    int value_c;
    int value_d;
	string textToDecode;

    string[] uPow = { "\u2070", "\u00B9", "\u00B2", "\u00B3", "\u2074", "\u2075", "\u2076", "\u2077", "\u2078", "\u2079", "\u00B9\u2070" };

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
        value_a = UnityEngine.Random.Range(-1,-5);
        value_b = UnityEngine.Random.Range(2, 5);
        value_c = UnityEngine.Random.Range(0, 4);
        for (int b = 0; b < arr.Length; b++)
            if (textToDecode[b].ToString() == "A") {
                newTitle += "\n<size=45>(</size> <size=55>-</size><size=28> " + value_b + " </size> <size=45>)";
                newTitle2 += "\n <size=45>(</size><size=55>-</size></color><size=28><u> " + Mathf.Abs(value_a) + "   </u></size><color=#8A00C9>  <size=45>)</size>";
            } else if (textToDecode[b].ToString() == "C") {
                newTitle += uPow[value_c]+"</size>";
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

        SetValue("" + Mathf.Pow(value_a,value_c)+"/"+Mathf.Pow(value_b, value_c));
        SetValue("" + Mathf.Pow(value_a, value_c+1) + "/" + Mathf.Pow(value_b, value_c+1));
        SetValue("" + (-1 * Mathf.Pow(value_a, value_c)) + "/" + Mathf.Pow(value_b, value_c));

        /*SetValue("" + Mathf.Pow(1f*value_a/value_b,value_c));
        SetValue("" + Mathf.Pow(1f*value_a / value_b, value_c+1));
        SetValue("" + (-1*Mathf.Pow(value_a / value_b, value_c)));*/
    }
	void SetValue(string number)
	{
        Debug.Log(number);
		//values.Add (Utils.SetFormatedNumber(number));
        values.Add(number);
    }
}
