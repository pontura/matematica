using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Kunak : MonoBehaviour {

	public GameObject KunakAvatar;
	public GameObject humoFX;
	public LoadingBar loadingBar;
	public Image mascara;
	public GameObject entradaBg;
	public float fadeSpeed;
	public Tween kunakDTween;
	public Tween buttonTween;
	public Tween sesionTween;
	public AudioSource kunaksfx;
	AudioSource source;

	public GameObject login;
	public GameObject noLogin;
	public InputField id;
    public InputField nombre;

    bool loadDone;
	bool fadeOut;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
		Events.KunakSfx += KunakSfx;
		Debug.Log (Data.Instance.levelData.kunakState);
		if (Data.Instance.levelData.kunakState == LevelsData.KunakStates.inicio) {
			loadingBar.transform.parent.gameObject.SetActive (true);
			StartCoroutine (AsynchronousLoad ("Kunak"));
		} else {
			entradaBg.SetActive (false);
			loadingBar.transform.parent.gameObject.SetActive (false);
			KunakSfx (true);
			StartCoroutine (AsynchronousLoad ("Game"));
		}
		Invoke ("CloseHumoFx", 3f);
        //ShowLogin();

    }

	void ShowLogin(){
        Debug.Log("Alumno: " + Data.Instance.esAlumno);
		sesionTween.gameObject.SetActive(!Data.Instance.esAlumno);
	}

	public void ShowLogin(bool enable){
		login.SetActive (enable);
	}

	public void Register(){
		bool val = Data.Instance.users.IsUser (id.text,nombre.text);
		ShowLogin ();		
        if (!val){
            noLogin.SetActive(true);
            Invoke("HideMessage", 3);
        }
        login.SetActive(false);
    }

	void HideMessage(){
        id.text = "";
        nombre.text = "";
        noLogin.SetActive (false);
	}

	void OnDestroy(){
		Events.KunakSfx -= KunakSfx;
	}

	void KunakSfx(bool enable){
		if (enable) {
			kunaksfx.Play (44100);
			source.Play ();
		}
	}

	void CloseHumoFx(){
		humoFX.SetActive (false);
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
		float r = Random.Range(0,10) * 0.05f;
		Data.Instance.interfaceSfx.ClickSfx (0.75f+r);
		if (Data.Instance.levelData.kunakState == LevelsData.KunakStates.inicio) {
			Data.Instance.levelData.kunakState = LevelsData.KunakStates.area;
			kunakDTween.reverse = true;
			kunakDTween.doTween = true;
			buttonTween.reverse = true;
			buttonTween.doTween = true;
			sesionTween.reverse = true;
			sesionTween.doTween = true;
			humoFX.SetActive (true);
			KunakAvatar.SetActive (false);
			source.pitch = 0.5f;
			source.Play ();
			Invoke ("WaitKunakExit",5);
		}else if (Data.Instance.levelData.kunakState == LevelsData.KunakStates.area) {
			kunakDTween.reverse = true;
			kunakDTween.doTween = true;
			buttonTween.reverse = true;
			buttonTween.doTween = true;
			sesionTween.reverse = true;
			sesionTween.doTween = true;
			humoFX.SetActive (true);
			KunakAvatar.SetActive (false);
			source.pitch = 0.5f;
			source.Play ();
			Invoke ("WaitKunakExit",5);
		} else if (Data.Instance.levelData.kunakState == LevelsData.KunakStates.dialog || Data.Instance.levelData.kunakState == LevelsData.KunakStates.allcomplete) {
			fadeOut = false;
			Events.NextDialog ();
		}
	}

	void WaitKunakExit(){
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
