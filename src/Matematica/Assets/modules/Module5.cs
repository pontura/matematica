using System.Collections.Generic;
using UnityEngine;

public class Module5 : ModuleData {

	int value_a;
	int value_b;
	int value_c;
	int value_number_of_zeros_1;
	int value_number_of_zeros_2;
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
			} else if (textToDecode [b].ToString () == "m") {
				value_number_of_zeros_1 = UnityEngine.Random.Range (3, 6);
				string newStr = "";
				for (int a = 0; a < value_number_of_zeros_1; a++) {
					newStr += "0";
				}
				newTitle = Utils.SetFormatedNumber ("2"+newTitle+ newStr);
			} else if (textToDecode [b].ToString () == "n") {
				value_number_of_zeros_2 = UnityEngine.Random.Range (2, 5);
				string newStr = "";
				for (int a = 0; a < value_number_of_zeros_2; a++) {
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

		int zeros = value_number_of_zeros_1 - value_number_of_zeros_2;

		string numberOfZeros = "";
		for (int a = 0; a < zeros; a++) {
			numberOfZeros += "0";
		}

		string ans_1 = "";
		string ans_2 = "";
		string ans_3 = "";
		if (numberOfZeros.Length > 1) {
			ans_1 = "2" + value_a.ToString() + value_b.ToString() + value_c.ToString() + numberOfZeros;
			ans_2 = "2" + value_a.ToString() + value_b.ToString() + value_c.ToString() + numberOfZeros + "0" ;
			ans_3 = "2" + value_a.ToString () + value_b.ToString () + value_c.ToString () + numberOfZeros.Substring (0, numberOfZeros.Length - 1);
		} else { 
			ans_1 = "2" + value_a.ToString() + value_b.ToString() + value_c.ToString() + numberOfZeros;
			ans_2 = "2" + value_a.ToString() + value_b.ToString() + value_c.ToString() + numberOfZeros + "0" ;
			ans_3 = "2" + value_a.ToString () + value_b.ToString () + value_c.ToString () + numberOfZeros;
			ans_3 = ans_3.Substring (0, ans_3.Length - 1);
		}
			

		SetValue (SetCeros("2" + value_a.ToString() + value_b.ToString() + value_c.ToString(), zeros));
		SetValue (SetCeros("2" + value_a.ToString() + value_b.ToString() + value_c.ToString(), zeros+1));
		SetValue (SetCeros("2" + value_a.ToString() + value_b.ToString() + value_c.ToString(), zeros-1));

	}
	void SetValue(string number)
	{
		values.Add (Utils.SetFormatedNumber(number));
	}


	string SetCeros(string num, int zeros){		
		if (zeros > 0) {
			string numberOfZeros = "";
			for (int a = 0; a < zeros; a++) {
				numberOfZeros += "0";
			}
			return num + numberOfZeros;
		} else if (zeros < 0) {
			//zeros = Mathf.Abs (zeros);
			if (num.Length + zeros > -1) {
				return num.Insert (num.Length + zeros, ",");
			} else {
				zeros = Mathf.Abs (num.Length + zeros);
				string numberOfZeros = "0";
				for (int a = 0; a < zeros; a++) {
					numberOfZeros += "0";
				}
				num = numberOfZeros + num;
				return num.Insert (1, ",");
			}				
		} else {
			return num;
		}

	}
}
