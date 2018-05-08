using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trivia : MonoBehaviour {
	public Text moduleField;
	public Text title;
	public ResultButton resultButton_to_instantiate;
	public Transform buttonsContainer;
	ModulesManager modulesManager;

	void Start()
	{
		modulesManager = Data.Instance.modulesManager;
	}
	public void PrevModule()
	{
		modulesManager.moduleID--;
		if (modulesManager.moduleID < 0)
			modulesManager.moduleID = 0;
		CreateNewModule ();
	}
	public void NextModule()
	{
		modulesManager.moduleID++;
		if (modulesManager.moduleID >= Data.Instance.settings.all.exercises.Count-1)
			modulesManager.moduleID = Data.Instance.settings.all.exercises.Count-1;
		CreateNewModule ();
	}
	public void CreateNewModule()
	{
		modulesManager.SetNewModuleActive ();
		moduleField.text = "MODULE " + modulesManager.actualModule.module;
		title.text = modulesManager.actualModule.title;
		Utils.RemoveAllChildsIn (buttonsContainer);
		foreach(string result in modulesManager.actualModule.values)
		{
			ResultButton button = Instantiate (resultButton_to_instantiate);
			button.transform.SetParent (buttonsContainer);
			button.transform.localScale = Vector3.one;
			button.Init (result);
		}
	}
}
