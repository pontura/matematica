using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class Settings : MonoBehaviour{

	public All all;

	void Start () {
		TextAsset jsonObj = Resources.Load(Path.Combine("JSON","data")) as TextAsset;
		all =  JsonUtility.FromJson< All >(jsonObj.text);
	}
	[Serializable]
	public class All
	{
		public List<ExercisesData> exercises;
	}
}
