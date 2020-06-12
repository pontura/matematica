using System.Collections.Generic;
using UnityEngine;

public class Module2_C : ModuleData {

    int sel;
    int value_a,value_ac,value_c,value_bc,value_b,value_ab,value_abc;
    string textToDecode;
    string[] conj = { "A","B","C","A\u2229B","A\u2229C","B\u2229C","A\u2229B\u2229C"}; // A, B, C, A&&B, A&&C, B&&C, A&&B&&C

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
		string newTitle = "";
        value_a = UnityEngine.Random.Range(1, 10);
        value_ac = UnityEngine.Random.Range(1, 10);
        value_c = UnityEngine.Random.Range(1, 10);
        value_bc = UnityEngine.Random.Range(1, 10);
        value_b = UnityEngine.Random.Range(1, 10);
        value_ab = UnityEngine.Random.Range(1, 10);
        value_abc = UnityEngine.Random.Range(1, 10);
        sel = UnityEngine.Random.Range(0, conj.Length);
        Events.SetOp2C(value_a,value_b,value_c,value_ab,value_bc,value_ac,value_abc);

        for (int b = 0; b < arr.Length; b++)
			if (textToDecode [b].ToString () == "T") {
                newTitle += conj[sel];
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
        int res = 0;
        switch (sel) {
            case 0:
                res = value_a + value_ac + value_ab + value_abc;              
                break;
            case 1:
                res = value_bc + value_b + value_ab + value_abc;
                break;
            case 2:
                res = value_bc + value_abc + value_c + value_ac;
                break;
            case 3:
                res = value_ab + value_abc;
                break;
            case 4:
                res = value_abc + value_ac;
                break;
            case 5:
                res = value_bc + value_abc;                
                break;
            case 6:
                res = value_abc;
                break;
            default:
                Debug.Log("valor seleccionado de conjunto fuera del rango");
                break;
        }
        Debug.Log("Res=" + res);
        SetValue("" + res);
        SetValue("" + (res + 1));
        SetValue("" + (res + 2));

    }
	void SetValue(string number)
	{
        Debug.Log(number);
		//values.Add (Utils.SetFormatedNumber(number));
        values.Add(number);
    }
}
