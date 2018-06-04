using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kunak : MonoBehaviour {

	public LoadingBar loadingBar;
	bool loadDone;

	// Use this for initialization
	void Start () {
		StartCoroutine (AsynchronousLoad("Game"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadScene(){
		loadDone = true;
	}

	IEnumerator AsynchronousLoad (string scene)
	{
		yield return null;

		AsyncOperation ao = SceneManager.LoadSceneAsync(scene);
		ao.allowSceneActivation = false;

		while (! ao.isDone)
		{			
			// [0, 0.9] > [0, 1]\
			float progress = Mathf.Clamp01(ao.progress / 0.9f);
			loadingBar.SetFill(progress);

			yield return new WaitForSeconds(1);
			// Loading completed
			/*if (ao.progress == 0.9f){
				loading.SetActive (false);
				playButton.SetActive (true);
			}*/

			if(loadDone)
				ao.allowSceneActivation = true;

			yield return null;
		}
	}
}
