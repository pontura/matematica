using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ModulesManager : MonoBehaviour {

	public ModuleData actualModule;
	public int moduleIndex;

	public void SetNewModuleActive () {

        Settings.Recorrido all = Data.Instance.settings.GetActualRecorrido();
        if (all != null) {
            ExercisesData data = all.ejercicios.exercises[moduleIndex];

            var type = Type.GetType(data.module);
            actualModule = (ModuleData)Activator.CreateInstance(type);

            /*if (data.module == 1)
                actualModule = new Module1();
            else if (data.module == 2)
                actualModule = new Module2();
            else if (data.module == 7)
                actualModule = new Module7();
            else if (data.module == 8)
                actualModule = new Module8();
            else if (data.module == 9)
                actualModule = new Module9();
            else if (data.module == 10)
                actualModule = new Module10();
            else if (data.module == 11)
                actualModule = new Module11();*/

            actualModule.Init(data);
        }
	}
}
