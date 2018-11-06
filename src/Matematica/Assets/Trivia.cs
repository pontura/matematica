using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trivia : MonoBehaviour {
	public Text moduleField;
	public Text title;
	public ResultButton resultButton_to_instantiate;
	public Transform buttonsContainer;
	public Image puntos;
	public Text NumPregunta;
	public Text debug;
	public GameObject levelSelector;

	ModulesManager modulesManager;

	int nPregunta;

	void Start()
	{
		modulesManager = Data.Instance.modulesManager;
		Events.NextExercise += NextExercise;
		Events.AddScore += AddScore;
		Events.AreaChange += AreaChange;

		LevelsData.Level l = Data.Instance.levelData.CurrentLevel;
		puntos.fillAmount = 1f * l.localPoints / l.length;

		if (Data.Instance.settings.all.exercises.Count > 0)
			NextExercise ();
		else
			Invoke ("NextExercise",1);
	}

	void OnDestroy(){
		Events.NextExercise -= NextExercise;
		Events.AddScore -= AddScore;
		Events.AreaChange -= AreaChange;
	}

	public void PrevModule()
	{
		modulesManager.moduleIndex--;
		if (modulesManager.moduleIndex < 0)
			modulesManager.moduleIndex = 0;
		CreateNewModule ();
	}
	public void NextModule()
	{
		modulesManager.moduleIndex++;
		if (modulesManager.moduleIndex >= Data.Instance.settings.all.exercises.Count-1)
			modulesManager.moduleIndex = Data.Instance.settings.all.exercises.Count-1;
		CreateNewModule ();
	}

	public void NextExercise()
	{
		nPregunta++;
		NumPregunta.text = "" + nPregunta;
		modulesManager.moduleIndex++;
		if (modulesManager.moduleIndex > Data.Instance.settings.all.exercises.Count-1)
			modulesManager.moduleIndex=0;
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

	public void ShowLevelSelector(bool enable){
		levelSelector.SetActive(enable);
	}

	void AreaChange(int i){
		puntos.fillAmount = 0;
	}

	void AddScore(){
		puntos.fillAmount += (1f/Data.Instance.levelData.CurrentLevel.length);
	}
}
