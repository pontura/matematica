using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Kunak : MonoBehaviour {

	public LoadingBar loadingBar;
	public Image mascara;
	public GameObject entradaBg;
	public float fadeSpeed;

	bool loadDone;
	bool fadeOut;

	// Use this for initialization
	void Start () {
		Debug.Log (Data.Instance.levelData.kunakState);
		if (Data.Instance.levelData.kunakState == LevelsData.KunakStates.inicio) {
			loadingBar.transform.parent.gameObject.SetActive (true);
			StartCoroutine (AsynchronousLoad ("Kunak"));
		} else {
			entradaBg.SetActive (false);
			loadingBar.transform.parent.gameObject.SetActive (false);
			StartCoroutine (AsynchronousLoad ("Game"));
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (fadeOut) {
			Color c = mascara.color;
			c.a += fadeSpeed;
			mascara.color = c;
			if (mascara.color.a >= 1) {
				loadDone = true;
				fadeOut = false;
			}				
		}
	}

	public void LoadScene(){
		if (Data.Instance.levelData.kunakState == LevelsData.KunakStates.inicio)
			Data.Instance.levelData.kunakState = LevelsData.KunakStates.area;
		fadeOut = true;
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
