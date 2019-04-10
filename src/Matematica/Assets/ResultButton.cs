using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultButton : MonoBehaviour {

	public Text field;
	public int id;
	public Sprite normalImg,goodImg,badImg;
	public AudioClip correcto, incorrecto;

	Image image;
	AudioSource audiosource;

	void Start(){
		image = GetComponentInChildren<Image> ();
		audiosource = GetComponent<AudioSource> ();
	}

	public void Init(string text, int id_)
	{
		field.text = text;
		id = id_;
	}

    public void SetResult()
    {
        Data.Instance.interfaceSfx.ClickSfx(1f);
        if (id == 0)
        {
            field.color = Color.white;
            image.sprite = goodImg;
            audiosource.clip = correcto;
            audiosource.Play();
        }
        else
        {
            field.color = Color.yellow;
            image.sprite = badImg;
            audiosource.clip = incorrecto;
            audiosource.Play();
        }

        Button[] buttons = transform.parent.GetComponentsInChildren<Button>();
        foreach (Button b in buttons)
        {
            b.interactable = false;
        }

        string resp = "";
        int score = 0;
        if (id == 0)
        {
            Events.AddScore();
            resp = "CORRECTA";
            score = 1;
        }
        else
        {
            Events.BadAnswer();
            resp = "INCORRECTA";
            Invoke("NextExercise", 2);
        }

        if (Data.Instance.esAlumno && Data.Instance.firebaseInitialized) {
            /* Firebase.Analytics.Parameter[] scoreParameters = {
                 new Firebase.Analytics.Parameter("ModuloNro",Data.Instance.modulesManager.actualModule.module),
                 new Firebase.Analytics.Parameter("Opcion_modelo",Data.Instance.modulesManager.actualModule.results[id]),
                 new Firebase.Analytics.Parameter("Opcion_valor",Data.Instance.modulesManager.actualModule.values[id]),
                 new Firebase.Analytics.Parameter("Consigna",Data.Instance.modulesManager.actualModule.title),
                 new Firebase.Analytics.Parameter("Respuesta",resp)
             };

             Firebase.Analytics.FirebaseAnalytics.LogEvent(Firebase.Analytics.FirebaseAnalytics.EventPostScore, scoreParameters);*/
            //Debug.Log("aca");

            string respMod = Data.Instance.modulesManager.actualModule.data.title.Replace("#", "")+                
                "&" + Data.Instance.modulesManager.actualModule.results[id] + "&" + resp;

            string respValor = Data.Instance.modulesManager.actualModule.title +
                "&" + Data.Instance.modulesManager.actualModule.values[id] + "&" + resp;

             Firebase.Analytics.Parameter[] scoreParameters = {
                 new Firebase.Analytics.Parameter("Modulo",respMod),
                 new Firebase.Analytics.Parameter("Valor",respValor)                 
             };

            Firebase.Analytics.FirebaseAnalytics.LogEvent(Firebase.Analytics.FirebaseAnalytics.EventPostScore, scoreParameters);         

        }


    }

	void NextExercise(){
		Events.NextExercise ();
	}
}
