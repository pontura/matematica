using UnityEngine;
using System.Collections;

public static class Utils {

    public static void RemoveAllChildsIn(Transform container)
    {
        int num = container.transform.childCount;
        for (int i = 0; i < num; i++) UnityEngine.Object.DestroyImmediate(container.transform.GetChild(0).gameObject);
    }
	public static string SetFormatedNumber(string n)
	{
		string[] arr = new string[n.Length];

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
	}
}
