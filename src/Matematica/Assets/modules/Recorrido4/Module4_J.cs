using System.Collections.Generic;
using UnityEngine;

public class Module4_J : ModuleData {

	int value_a;
	int value_b;
    int value_c;
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
        value_a = UnityEngine.Random.Range(1, 9);
        value_b = UnityEngine.Random.Range(0, 9);
        value_c = UnityEngine.Random.Range(1, 9);
        for (int b = 0; b < arr.Length; b++)
            if (textToDecode[b].ToString() == "A") {
                newTitle += "\n-<size=28>0,"+ value_a;
            } else if (textToDecode[b].ToString() == "B") {
                newTitle += "" + value_b;
            } else if (textToDecode[b].ToString() == "C") {
                newTitle += "" + value_c+"</size>";
            } else {
                newTitle += textToDecode[b].ToString();
            }
        Debug.Log(newTitle);
        title = title.Replace("#", newTitle);
        Debug.Log(title);
        Events.SetPeriodicTitle("<size=35>)</size>");
        SetResults (data.results);
			
		CheckValues ();

	}
	void SetResults(List<string> data)
	{
		results = data;
		values = new List<string> ();

        SetValue("-" +value_a+value_b+value_c+"/999");
        SetValue("-" + value_a + value_b + value_c + "/900");
        SetValue("-" + value_a + value_b + value_c + "/990");
    }
	void SetValue(string number)
	{
        Debug.Log(number);
		//values.Add (Utils.SetFormatedNumber(number));
        values.Add(number);
    }
}