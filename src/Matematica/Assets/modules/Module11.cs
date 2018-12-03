using System.Collections.Generic;
using UnityEngine;

public class Module11 : ModuleData {

	int value_a;
	int value_b;
	int value_c;
	string textToDecode;

	public override void Init(ExercisesData data) 
	{ 
		base.Init (data);

		title =  data.title;
		Calculate ();
	}
	void Calculate(){
		value_a = UnityEngine.Random.Range (2, 5);
		value_b = UnityEngine.Random.Range (11, 99);
		value_c = UnityEngine.Random.Range (11, 99);

		title = title.Replace ("*a", "" + value_a);
		title = title.Replace ("*n", "" + value_b);
		title = title.Replace ("*m", "" + value_c);

		SetResults (data.results);
		//CheckValues ();

	}
	void SetResults(List<string> data)
	{
		results = data;
		values = new List<string> ();

		string s = data[0];
		s = s.Replace ("*a", GetVal(value_a));
		s = s.Replace ("*n", "" + value_b);
		s = s.Replace ("*m", "" + value_c);	
		values.Add (s);
		s = data[1];
		s = s.Replace ("*a", GetVal(value_a));
		s = s.Replace ("*n", "" + value_b);
		s = s.Replace ("*m", "" + value_c);	
		values.Add (s);

		s = data[2];
		s = s.Replace ("*a", GetVal(value_a+1));
		s = s.Replace ("*n", "" + value_b);
		s = s.Replace ("*m", "" + value_c);	
		values.Add (s);

	}

	string GetVal(int x){
		if (x == 2)
			return "doble";
		if (x == 3)
			return "triple";
		if (x == 4)
			return "cuádruple";
		if (x == 5)
			return "quíntuple";
		if (x == 6)
			return "séxtuple";
		else
			return "";
				
	}
}

