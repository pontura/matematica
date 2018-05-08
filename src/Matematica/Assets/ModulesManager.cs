using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModulesManager : MonoBehaviour {

	public ModuleData actualModule;
	public int moduleID;

	public void SetNewModuleActive () {

		ExercisesData data = Data.Instance.settings.all.exercises[moduleID];

		if(data.module == 1)
			actualModule = new Module1 ();
		else if(data.module == 2)
			actualModule = new Module2 ();
		else if(data.module == 3)
			actualModule = new Module3 ();
		else if(data.module == 4)
			actualModule = new Module4 ();

		actualModule.Init (data);
	}
}
