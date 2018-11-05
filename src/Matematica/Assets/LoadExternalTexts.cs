using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class LoadExternalTexts : MonoBehaviour {

	public string filename="Frases_Kumak.csv";

	public ExternalText[] externalTexts;

	[Serializable]
	public class ExternalText
	{
		public int id;
		public string condition;
		public string frase;
		public string button_text;
	}

	void Start () {

		string filePath = Path.Combine (Application.streamingAssetsPath + "/", filename);
		if (File.Exists (filePath)) {			
			string dataAsJson = Utils.CSV2JSON(File.ReadAllText (filePath),'#');
			externalTexts = JsonHelper.FromJson<ExternalText> (dataAsJson);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
