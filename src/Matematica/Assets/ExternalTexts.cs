using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class ExternalTexts : MonoBehaviour {

	public string filename="Frases_Kumak.csv";

	public ExternalText[] texts;

	[Serializable]
	public class ExternalText
	{
		public int id;
		public int area_id;
		public int dialog_index;
		public string condition;
		public string frase;
		public string button_text;
		public bool next;
	}

	void Start () {

		/*string filePath = "";
		#if UNITY_EDITOR
			filePath = Path.Combine (Application.streamingAssetsPath + "/", filename);
		#elif UNITY_ANDROID
			filePath = "jar:file://" + Application.dataPath + "!/assets/" + filename;
			Debug.Log ("ANDROID");
		#endif*/
		string filePath = Path.Combine (Application.streamingAssetsPath + "/", filename);
		StartCoroutine(LoadFile(filePath));

		/*Debug.Log (filePath);
		if (File.Exists (filePath)) {			
			Debug.Log ("exists");
			string dataAsJson = Utils.CSV2JSON (File.ReadAllText (filePath), '#');
			Debug.Log (dataAsJson);
			texts = JsonHelper.FromJson<ExternalText> (dataAsJson);
		} else {
			Debug.Log ("no exists");
		}*/
	}

	IEnumerator LoadFile(string filePath) {
		string text = "";
		if (filePath.Contains("://")) {
			using (WWW www = new WWW(filePath))
			{
				yield return www;
				text = www.text;
			}
		} else
			text = System.IO.File.ReadAllText(filePath);

		string dataAsJson = Utils.CSV2JSON (text, '#');
		//Debug.Log (dataAsJson);
		texts = JsonHelper.FromJson<ExternalText> (dataAsJson);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
