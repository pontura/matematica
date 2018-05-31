using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModulesManager : MonoBehaviour {

	public ModuleData actualModule;
	public int moduleIndex;

	public void SetNewModuleActive () {

		ExercisesData data = Data.Instance.settings.all.exercises[moduleIndex];

		if(data.module == 1)
			actualModule = new Module1 ();
		else if(data.module == 2)
			actualModule = new Module2 ();
		else if(data.module == 7)
			actualModule = new Module7 ();
		else if(data.module == 8)
			actualModule = new Module8 ();
		else if(data.module == 9)
			actualModule = new Module9 ();

		actualModule.Init (data);
	}
}
