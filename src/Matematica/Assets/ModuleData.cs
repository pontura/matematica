﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class ModuleData  {

	public int module;
	public string title;
	public List<string> results;
	public List<string> values;
	public ExercisesData data;

	public virtual void Init(ExercisesData data) 
	{ 		
		this.data = data;
		this.module = data.module;
	}

}
