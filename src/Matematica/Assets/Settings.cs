using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class Settings : MonoBehaviour{

	public List<Recorrido> recorridos;
    public Recorrido selectedRecorrido;

	void Start () {
        recorridos = new List<Recorrido>();
        AddJsonData("data",0);
        AddJsonData("recorrido1",1);
        AddJsonData("recorrido2", 2);
        AddJsonData("recorrido3", 3);
        AddJsonData("recorrido4", 4);
        AddJsonData("recorrido5", 5);
        AddJsonData("recorrido6", 6);
        AddJsonData("recorrido7", 7);
    }

    void AddJsonData(string jsonName, int id) {
        TextAsset json = Resources.Load(Path.Combine("JSON", jsonName)) as TextAsset;
        Recorrido a = new Recorrido();
        a.id = id;
        a.ejercicios = JsonUtility.FromJson<Ejercicios>(json.text);
        recorridos.Add(a);
    }

	[Serializable]
	public class Recorrido
	{
        public int id;
		public Ejercicios ejercicios;
	}

    [Serializable]
    public class Ejercicios {
        public List<ExercisesData> exercises;
    }

    public Recorrido GetModulesFromMode(int id) {
        return recorridos.Find(x => x.id == id);
    }

    public Recorrido GetActualRecorrido() {
        if (selectedRecorrido == null || selectedRecorrido.ejercicios.exercises.Count<=0) {
            selectedRecorrido = recorridos.Find(x => x.id == Data.Instance.playerData.mode);
        }
        return selectedRecorrido;
    }
}
