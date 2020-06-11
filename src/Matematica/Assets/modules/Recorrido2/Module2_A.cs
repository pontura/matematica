using System.Collections.Generic;
using UnityEngine;

public class Module2_A : ModuleData {

    int value_a,value_b;
    string textToDecode;
    string[] op = { "\u2229", "\u222A", "-" }; // &&, ||, -

    public override void Init(ExercisesData data) 
	{ 
		base.Init (data);

        /*string titleData = data.title;
		string[] titleDataArr = titleData.Split ("#" [0]);
		title =  titleDataArr [0] + "#" + titleDataArr[2];
		textToDecode = titleDataArr [1];
		Calculate ();*/
        title = data.title;
        value_a = UnityEngine.Random.Range(0, op.Length);
        value_b = UnityEngine.Random.Range(0, op.Length);
        Events.SetOp2A(value_a, value_b);
        SetResults(data.results);
    }
	void Calculate()
	{
		string[] arr = new string[textToDecode.Length];
		string newTitle = "";
        value_a = UnityEngine.Random.Range(3,20);

        for (int b = 0; b < arr.Length; b++)
			if (textToDecode [b].ToString () == "A") {				
				newTitle += (value_a);			
			}else
            newTitle += textToDecode [b].ToString ();			

			title = title.Replace("#",newTitle);
			SetResults (data.results);
			
			CheckValues ();

	}
	void SetResults(List<string> data)
	{
		results = data;
		values = new List<string> ();

        SetValue("A"+ op[value_a] + "(B"+ op[value_b] + "C)");
        if (value_a != value_b) {
            SetValue("A" + op[value_b] + "(B" + op[value_a] + "C)");
            SetValue("A" + op[value_a] + "(B" + op[value_a] + "C)");
        } else {
            int c = value_a + 1;
            c = c >= op.Length ? 0 : c;
            SetValue("A" + op[c] + "(B" + op[value_a] + "C)");
            SetValue("A" + op[c] + "(B" + op[c] + "C)");
        }
    }
	void SetValue(string number)
	{
        Debug.Log(number);
		//values.Add (Utils.SetFormatedNumber(number));
        values.Add(number);
    }
}
