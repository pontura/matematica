using System.Collections.Generic;
using UnityEngine;

public class Module4_C : ModuleData {

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
        value_a = UnityEngine.Random.Range(-5, -9);
        value_b = UnityEngine.Random.Range(4, Mathf.Abs(value_a));
        value_c = UnityEngine.Random.Range(-3, -1*value_b);
        value_d = UnityEngine.Random.Range(2, Mathf.Abs(value_c));
        for (int b = 0; b < arr.Length; b++)
            if (textToDecode[b].ToString() == "A") {
                if (value_a < 0) {
                    newTitle += "\n<size=45>(</size> <size=55>-</size> <size=28>  " + value_b + "   </size><size=45>)</size>";
                    newTitle2 += "\n <size=45>(</size> <size=55>-</size></color><size=28><u> " + Mathf.Abs(value_a) + "  </u></size><color=#8A00C9> <size=45>)</size></color>";
                } else {
                    newTitle += " <size=28> " + value_b + " </size>";
                    newTitle2 += "</color><size=28><u> " + value_a + " </u></size>";
                }
            } else if (textToDecode[b].ToString() == "C") {
                if (value_a < 0) {
                    newTitle += "<size=45>(</size> <size=55>-</size><size=28>  " + value_d + "  </size><size=45>)</size>";
                    newTitle2 += "<color=#8A00C9><size=45>(</size> <size=55>-</size></color> <size=28><u> " + Mathf.Abs(value_c) + " </u></size><color=#8A00C9><size=45>)</size>";
                } else {
                    newTitle += " <size=28> " + value_d + " </size>";
                    newTitle2 += " <size=28><u> " + value_c + " </u></size><color=#8A00C9>";
                }
            } else {
                newTitle += textToDecode[b].ToString();
                newTitle2 += textToDecode[b].ToString();
            }
        Debug.Log(newTitle);
        Debug.Log(newTitle2);
        newTitle = newTitle.Replace(".", "<color=#8A00C9><size=50>.</size></color>");
        newTitle2 = newTitle2.Replace(".", "<size=50>.</size>");
        string title2 = "<color=#8A00C9>" +title+ "</color>";
        title = title.Replace("*", newTitle);
        Debug.Log(title);
        Events.SetTitleDenom(title2.Replace("*", newTitle2));
        Debug.Log(title2.Replace("*", newTitle2));
        SetResults (data.results);
			
		CheckValues ();

	}
    void SetResults(List<string> data) {
        results = data;
        values = new List<string>();
        if (value_a * value_c * value_b * value_d > 0) {
            SetValue("" + (Mathf.Abs(1.0f * value_a * value_c) + "/" + Mathf.Abs(value_b * value_d)));
            SetValue("" + (Mathf.Abs(1.0f * value_a * value_d) + "/" + Mathf.Abs(value_b * value_c)));
            SetValue("" + (Mathf.Abs(1.0f * value_a * value_b) + "/" + Mathf.Abs(value_d * value_c)));
        } else {
            SetValue("-" + (Mathf.Abs(1.0f * value_a * value_c) + "/" + Mathf.Abs(value_b * value_d)));
            SetValue("-" + (Mathf.Abs(1.0f * value_a * value_d) + "/" + Mathf.Abs(value_b * value_c)));
            SetValue("-" + (Mathf.Abs(1.0f * value_a * value_b) + "/" + Mathf.Abs(value_d * value_c)));
        }
    }

	void SetValue(string number)
	{
        Debug.Log(number);
		//values.Add (Utils.SetFormatedNumber(number));
        values.Add(number);
    }
}
