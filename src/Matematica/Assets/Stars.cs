using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour {

	public GameObject[] stars;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetStars(int index){
		for (int i = 0; i < stars.Length; i++)
			stars [i].SetActive (i == index);			
	}
}
