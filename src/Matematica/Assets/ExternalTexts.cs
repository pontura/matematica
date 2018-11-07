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

		string filePath = Path.Combine (Application.streamingAssetsPath + "/", filename);
		if (File.Exists (filePath)) {			
			string dataAsJson = Utils.CSV2JSON(File.ReadAllText (filePath),'#');
			texts = JsonHelper.FromJson<ExternalText> (dataAsJson);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
