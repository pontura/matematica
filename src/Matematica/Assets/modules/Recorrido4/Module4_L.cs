using System.Collections.Generic;
using UnityEngine;

public class Module4_L : ModuleData {

	int value_a;
	int value_b;
	string textToDecode;

	public override void Init(ExercisesData data) 
	{ 
		base.Init (data);

		string titleData = data.title;
		string[] titleDataArr = titleData.Split ("#" [0]);
        title = titleDataArr[0] + "#" + titleDataArr[2];
        textToDecode = titleDataArr [1];
		Calculate ();
	}
    void Calculate() {
        string[] arr = new string[textToDecode.Length];
        string newTitle = "";
        value_a = UnityEngine.Random.Range(2, 10);
        value_b = UnityEngine.Random.Range(1, value_a);
        for (int b = 0; b < arr.Length; b++)
            if (textToDecode[b].ToString() == "A") {
                newTitle += "\n-<size=24>0,"+ value_a+value_b + "</size>";
            } else if (textToDecode[b].ToString() == "B") {
                newTitle += "-<size=24>0," + value_a + value_b + "</size>";
            } else if (textToDecode[b].ToString() == "C") {
                newTitle += "-<size=24>0," + value_a + value_b + "</size>";
            } else {
                newTitle += textToDecode[b].ToString();
            }
        Debug.Log(newTitle);
        title = title.Replace("#", newTitle);
        Debug.Log(title);
        Events.SetPeriodicTitle2("<size=18>)</size>","<size=30>)</size>");
        SetResults (data.results);
			
		CheckValues ();

	}
	void SetResults(List<string> data)
	{
		results = data;
		values = new List<string> ();

        SetValue("-0," + value_a + value_b + "@PeriodicAB");
        SetValue("-0," + value_a + value_b + "@PeriodicB");        
        SetValue("-0," + value_a + value_b);
    }
	void SetValue(string number)
	{
        Debug.Log(number);
		//values.Add (Utils.SetFormatedNumber(number));
        values.Add(number);
    }
}