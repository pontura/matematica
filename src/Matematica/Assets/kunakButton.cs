using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kunakButton : MonoBehaviour {

    public bool tweenOnEnable;
	Tween tween;

	// Use this for initialization
	void Start () {
		tween = GetComponent<Tween> ();
	}

	void OnEnable(){
        if (tweenOnEnable) {
            if (tween == null)
                tween = GetComponent<Tween>();
            tween.doTween = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
