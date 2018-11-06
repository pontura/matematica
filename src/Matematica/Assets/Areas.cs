using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Areas : MonoBehaviour {

	public List<Area> areas;

	int actualArea;

	// Use this for initialization
	void Start () {
		Events.AreaChange += AreaChange;
		Events.SubAreaChange += SubAreaChange;
	}

	void OnDestroy(){
		Events.AreaChange -= AreaChange;
		Events.SubAreaChange -= SubAreaChange;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void AreaChange(int id){
		for (int i = 0; i < areas.Count; i++){			
			areas[i].gameObject.SetActive (id == areas[i].id);
			if (id == areas [i].id)
				actualArea = i;
		}
	}

	void SubAreaChange(int index){
		for (int i = 0; i < areas [actualArea].subareas.Count; i++) {
			if (i == index)
				areas [actualArea].subareas [i].SetActive (true);
			else
				areas [actualArea].subareas [i].SetActive (false);
		}
	}
}
