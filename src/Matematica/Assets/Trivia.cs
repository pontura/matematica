using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trivia : MonoBehaviour {
	public Text moduleField;
	public Text title;
	public ResultButton resultButton_to_instantiate;
	public Transform buttonsContainer;
	public Slider puntos;
	public Text debug;
	ModulesManager modulesManager;

	void Start()
	{
		modulesManager = Data.Instance.modulesManager;
		Events.NextExercise += NextExercise;
		Events.AddScore += AddScore;
		Invoke ("NextExercise",1);
	}

	void OnDestroy(){
		Events.NextExercise -= NextExercise;
		Events.AddScore -= AddScore;
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

	public void NextExercise()
	{
		modulesManager.moduleID++;
		if (modulesManager.moduleID >= Data.Instance.settings.all.exercises.Count-1)
			modulesManager.moduleID=0;
		CreateNewModule ();
	}

	public void CreateNewModule()
	{
		modulesManager.SetNewModuleActive ();
		moduleField.text = "MODULE " + modulesManager.actualModule.module;
		title.text = modulesManager.actualModule.title;
		debug.text = modulesManager.actualModule.data.title.Replace('#',' ');
		Utils.RemoveAllChildsIn (buttonsContainer);
		for(int i=0;i<modulesManager.actualModule.results.Count;i++){
			ResultButton button = Instantiate (resultButton_to_instantiate);
			button.transform.SetParent (buttonsContainer);
			button.transform.localScale = Vector3.one;
			button.Init (modulesManager.actualModule.values [i], i == 0);
		}
		ShuffleChildOrder (buttonsContainer);
	}

	public void ShuffleChildOrder(Transform container){
		for (int i = 0; i < container.childCount; i++) {
			Transform t = container.GetChild (i);
			if (Random.value < 0.3f)
				t.transform.SetAsFirstSibling ();
			else if (Random.value < 0.6)
				t.transform.SetAsLastSibling ();
		}
	}

	void AddScore(){
		puntos.value += 0.1f;
	}
}
