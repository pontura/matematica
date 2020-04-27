using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSelector : MonoBehaviour
{
    public List<GameObject> detalle;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject go in detalle)
            go.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDetalle(int i) {
        detalle[i].SetActive(true);
    }

    public void HideDetalle(int i) {
        detalle[i].SetActive(false);
    }

    public void SelectMode(int i) {
        Data.Instance.playerData.SetMode(i);
        Data.Instance.levelData.kunakState = LevelsData.KunakStates.area;
        Data.Instance.LoadScene("Kunak");
    }
}
