using System.Collections.Generic;
using UnityEngine;

public class Module4 : ModuleData {

	int value_a;
	int value_b;
	int value_c;
	int value_d;
	int value_number_of_zeros;
	string textToDecode;

	public override void Init(ExercisesData data) 
	{ 
		base.Init (data);

		string titleData = data.title;
		string[] titleDataArr = titleData.Split ("#" [0]);
		title =  titleDataArr [0];
		textToDecode = titleDataArr [1];
		Calculate ();
	}
	void Calculate()
	{
		string[] arr = new string[textToDecode.Length];
		string newTitle = "";
		for (int b = 0; b < arr.Length; b++)
			if (textToDecode [b].ToString () == "a") {
				value_a = UnityEngine.Random.Range (0, 9);
				newTitle += value_a;
			} else if (textToDecode [b].ToString () == "b") {
				value_b = UnityEngine.Random.Range (0, 9);
				newTitle += value_b;
			} else if (textToDecode [b].ToString () == "c") {
				value_c = UnityEngine.Random.Range (0, 9);
				newTitle += value_c;
			} else if (textToDecode [b].ToString () == "d") {
				value_d = UnityEngine.Random.Range (0, 9);
				newTitle += value_d;
			} else if (textToDecode [b].ToString () == "n") {
				value_number_of_zeros = UnityEngine.Random.Range (2, 6);
				string newStr = "";
				for (int a = 0; a < value_number_of_zeros; a++) {
					newStr += "0";
				}
				newTitle += Utils.SetFormatedNumber ("1" + newStr);
			} else
				newTitle += textToDecode [b].ToString ();

			title += newTitle;
			SetResults (data.results);

	}
	void SetResults(List<string> data)
	{
		results = data;
		values = new List<string> ();

		//
		//
		//

		string numberOfZeros = "";
		for (int a = 0; a < value_number_of_zeros; a++) {
			numberOfZeros += "0";
		}
		SetValue ("1" + value_a.ToString() + value_b.ToString() + value_c.ToString() + value_d.ToString() + numberOfZeros );
		SetValue ("1" + value_a.ToString() + value_b.ToString() + value_c.ToString() + value_d.ToString() + numberOfZeros + "0" );
		SetValue ("1" + value_a.ToString() + value_b.ToString() + value_c.ToString() + value_d.ToString() + numberOfZeros.Substring(0, numberOfZeros.Length - 1) );
	}
	void SetValue(string number)
	{
		values.Add (Utils.SetFormatedNumber(number));
	}
}
