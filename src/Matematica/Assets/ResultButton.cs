using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;

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
        string[] s = text.Split('@');
		field.text = s[0];
		id = id_;
        if (s.Length > 1) {
            System.Type thisType = this.GetType();
            MethodInfo theMethod = thisType.GetMethod(s[1]);
            theMethod.Invoke(this, null);
        }

	}

    public void PeriodicABC() {
        GameObject perioT = GameObject.Instantiate(field.gameObject);
        perioT.transform.parent = field.transform.parent;
        perioT.transform.SetAsLastSibling();
        Text text = perioT.GetComponent<Text>();
        //text.rectTransform.localPosition = new Vector3(title.rectTransform.localPosition.x, title.rectTransform.localPosition.y + 40, title.rectTransform.localPosition.z);
        text.rectTransform.localPosition = new Vector3(50, 35, 0);
        text.rectTransform.sizeDelta = new Vector2(100, 100);
        text.rectTransform.rotation = Quaternion.Euler(0f, 0f, -90f);
        text.rectTransform.localScale = Vector3.one;
        text.text = "(";
        text.resizeTextForBestFit = false;
        text.fontSize = 70;
        text.raycastTarget = false;
    }

    public void PeriodicC() {
        GameObject perioT = GameObject.Instantiate(field.gameObject);
        perioT.transform.parent = field.transform.parent;
        perioT.transform.SetAsLastSibling();
        Text text = perioT.GetComponent<Text>();
        //text.rectTransform.localPosition = new Vector3(title.rectTransform.localPosition.x, title.rectTransform.localPosition.y + 40, title.rectTransform.localPosition.z);
        text.rectTransform.localPosition = new Vector3(75, 30, 0);
        text.rectTransform.sizeDelta = new Vector2(100, 100);
        text.rectTransform.rotation = Quaternion.Euler(0f, 0f, -90f);
        text.rectTransform.localScale = Vector3.one;
        text.text = "(";
        text.resizeTextForBestFit = false;
        text.fontSize = 40;
        text.raycastTarget = false;
    }

    public void PeriodicB() {
        GameObject perioT = GameObject.Instantiate(field.gameObject);
        perioT.transform.parent = field.transform.parent;
        perioT.transform.SetAsLastSibling();
        Text text = perioT.GetComponent<Text>();
        //text.rectTransform.localPosition = new Vector3(title.rectTransform.localPosition.x, title.rectTransform.localPosition.y + 40, title.rectTransform.localPosition.z);
        text.rectTransform.localPosition = new Vector3(60, 30, 0);
        text.rectTransform.sizeDelta = new Vector2(100, 100);
        text.rectTransform.rotation = Quaternion.Euler(0f, 0f, -90f);
        text.rectTransform.localScale = Vector3.one;
        text.text = "(";
        text.resizeTextForBestFit = false;
        text.fontSize = 40;
        text.raycastTarget = false;
    }

    public void PeriodicA() {
        GameObject perioT = GameObject.Instantiate(field.gameObject);
        perioT.transform.parent = field.transform.parent;
        perioT.transform.SetAsLastSibling();
        Text text = perioT.GetComponent<Text>();
        //text.rectTransform.localPosition = new Vector3(title.rectTransform.localPosition.x, title.rectTransform.localPosition.y + 40, title.rectTransform.localPosition.z);
        text.rectTransform.localPosition = new Vector3(35, 30, 0);
        text.rectTransform.sizeDelta = new Vector2(100, 100);
        text.rectTransform.rotation = Quaternion.Euler(0f, 0f, -90f);
        text.rectTransform.localScale = Vector3.one;
        text.text = "(";
        text.resizeTextForBestFit = false;
        text.fontSize = 40;
        text.raycastTarget = false;
    }

    public void PeriodicAB() {
        GameObject perioT = GameObject.Instantiate(field.gameObject);
        perioT.transform.parent = field.transform.parent;
        perioT.transform.SetAsLastSibling();
        Text text = perioT.GetComponent<Text>();
        //text.rectTransform.localPosition = new Vector3(title.rectTransform.localPosition.x, title.rectTransform.localPosition.y + 40, title.rectTransform.localPosition.z);
        text.rectTransform.localPosition = new Vector3(45, 30, 0);
        text.rectTransform.sizeDelta = new Vector2(100, 100);
        text.rectTransform.rotation = Quaternion.Euler(0f, 0f, -90f);
        text.rectTransform.localScale = Vector3.one;
        text.text = "(";
        text.resizeTextForBestFit = false;
        text.fontSize = 63;
        text.raycastTarget = false;
    }

    public void PeriodicBC() {
        GameObject perioT = GameObject.Instantiate(field.gameObject);
        perioT.transform.parent = field.transform.parent;
        perioT.transform.SetAsLastSibling();
        Text text = perioT.GetComponent<Text>();
        //text.rectTransform.localPosition = new Vector3(title.rectTransform.localPosition.x, title.rectTransform.localPosition.y + 40, title.rectTransform.localPosition.z);
        text.rectTransform.localPosition = new Vector3(65, 30, 0);
        text.rectTransform.sizeDelta = new Vector2(100, 100);
        text.rectTransform.rotation = Quaternion.Euler(0f, 0f, -90f);
        text.rectTransform.localScale = Vector3.one;
        text.text = "(";
        text.resizeTextForBestFit = false;
        text.fontSize = 63;
        text.raycastTarget = false;
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
