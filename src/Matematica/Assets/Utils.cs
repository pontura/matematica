using UnityEngine;
using System.Collections;

public static class Utils {

    public static void RemoveAllChildsIn(Transform container)
    {
        int num = container.transform.childCount;
        for (int i = 0; i < num; i++) UnityEngine.Object.DestroyImmediate(container.transform.GetChild(0).gameObject);
    }
	/*public static string SetFormatedNumber(string n)
	{
		int i = n.Length;
		int num_id = 0;
		string returnString = "";
		while (i > 0) {
			char c = n[i - 1];
			if (num_id >= 3) {
				num_id = 0;
				returnString = c + "." + returnString;
			} else {				
				returnString = c + returnString;
			}
			num_id++;
			i--;
		}
		return returnString;
	}*/

	public static string SetFormatedNumber(string n){
		string[] arr = n.Split (',');

		string returnString = "";
		for (int i = 1; i < arr[0].Length+1; i++) {
			if (i%3 == 0 && i!=arr[0].Length) {				
				returnString = "." + arr[0][arr[0].Length-i] + returnString;
			} else {				
				returnString = arr[0][arr[0].Length-i] + returnString;
			}
		}
		if (arr [0].Length < 1)
			returnString = "0";
		if (arr.Length > 1)
			returnString += ","+arr [1];
		return returnString;
	}

	public static string CSV2JSON(string csv, char delimiter){
		string[] lines = csv.Split ('\n');
		string[] keys = lines [0].Split (delimiter);
		string json = "{ \"Items\":[";
		//Debug.Log (csv);
		for (int i = 1; i < lines.Length; i++) {
			string[] vals = lines [i].Split (delimiter);
			if (vals [0] != "") {
				if (i > 1)
					json += ",";
				json += "{";
				for (int j = 0; j < vals.Length; j++) {				
					json += keys [j] + ":" + vals [j];
					if (j < keys.Length - 1)
						json += ",";
				}
				json += "}";	
			}
		}
		json += "]}";
		//Debug.Log (json);
		return json;
	}
}
