using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Creditos : MonoBehaviour {

	public float pausaInicial;
	public float speed;
	RectTransform rt;

	Vector3 originalPos;
	bool run;
	float yLimit = 2300;

	// Use this for initialization
	void Start () {
		rt = GetComponent<RectTransform> ();
		originalPos = rt.position;
	}

	void OnEnable(){
		if (rt == null) {
			rt = GetComponent<RectTransform> ();
			originalPos = rt.position;
		}
		run = false;

		rt.position = originalPos;
		Invoke ("Run", pausaInicial);
	}

	void Run(){
		run = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(run){
			Vector3 p =	rt.position;

			rt.position = new Vector3 (p.x, p.y + speed, p.z);
			Debug.Log (p.y);
			if (p.y >= yLimit) {
				rt.position = new Vector3 (p.x, 0, p.z);
				run = false;
				Events.ShowLevelMenu (true);
			}
		}


	}
}
