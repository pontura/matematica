using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConjuntosManager : MonoBehaviour
{
    public GameObject container;
    public GameObject A, B, C, AB, BC, AC, ABC;
    public Text textA, textB, textC, textAB, textBC, textAC, textABC;

    string[] op = { "\u2239", "\u223A", "-" }; // &&, ||, -

    // Start is called before the first frame update
    void Awake()
    {
        Events.SetOp2A += SetOp2A;
        Events.SetOp2B += SetOp2B;
    }

    private void OnDestroy() {
        Events.SetOp2A -= SetOp2A;
        Events.SetOp2B -= SetOp2B;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetOp2A(int a, int b) { 
        Debug.Log(a + " : " + b);
        container.SetActive(true);
        HideAll();
        if (a == 0) {
            if (b == 0) {
                ABC.SetActive(true);
            } else if (b == 1) {
                ABC.SetActive(true);
                AB.SetActive(true);
                AC.SetActive(true);
            } else if (b == 2) {
                AB.SetActive(true);
            }
        }else if (a == 1) {
            if (b == 0) {
                A.SetActive(true);
                AB.SetActive(true);
                ABC.SetActive(true);
                BC.SetActive(true);
                AC.SetActive(true);
            } else if (b == 1) {
                ShowAll();
            } else if (b == 2) {
                A.SetActive(true);
                B.SetActive(true);
                AB.SetActive(true);
                AC.SetActive(true);
                ABC.SetActive(true);
            }
        } else if (a == 2) {
            if (b == 0) {
                A.SetActive(true);
                AB.SetActive(true);
                AC.SetActive(true);
            } else if (b == 1) {
                A.SetActive(true);
            } else if (b == 2) {
                A.SetActive(true);
                AC.SetActive(true);
                ABC.SetActive(true);
            }
        }
    }

    void SetOp2B(int a, int b) {
        Debug.Log(a + " : " + b);
        container.SetActive(true);
        HideAll();
        if (a == 0) {
            if (b == 0) {
                ABC.SetActive(true);
            } else if (b == 1) {
                ABC.SetActive(true);
                AB.SetActive(true);
                AC.SetActive(true);
                BC.SetActive(true);
                C.SetActive(true);
            } else if (b == 2) {
                AB.SetActive(true);
            }
        } else if (a == 1) {
            if (b == 0) {
                ABC.SetActive(true);
                BC.SetActive(true);
                AC.SetActive(true);
            } else if (b == 1) {
                ShowAll();
            } else if (b == 2) {
                A.SetActive(true);
                B.SetActive(true);
                AB.SetActive(true);
            }
        } else if (a == 2) {
            if (b == 0) {
                AC.SetActive(true);
            } else if (b == 1) {
                A.SetActive(true);
                AC.SetActive(true);
                ABC.SetActive(true);
                BC.SetActive(true);
                C.SetActive(true);
            } else if (b == 2) {
                A.SetActive(true);
            }
        }
    }

    void HideAll() {
        A.SetActive(false);
        B.SetActive(false);
        C.SetActive(false);
        AB.SetActive(false);
        AC.SetActive(false);
        BC.SetActive(false);
        ABC.SetActive(false);
    }

    void ShowAll() {
        A.SetActive(true);
        B.SetActive(true);
        C.SetActive(true);
        AB.SetActive(true);
        AC.SetActive(true);
        BC.SetActive(true);
        ABC.SetActive(true);
    }

    void HideAllText() {
        textA.gameObject.SetActive(false);
        textB.gameObject.SetActive(false);
        textC.gameObject.SetActive(false);
        textAB.gameObject.SetActive(false);
        textAC.gameObject.SetActive(false);
        textBC.gameObject.SetActive(false);
        textABC.gameObject.SetActive(false);
    }

    void ShowAllText() {
        textA.gameObject.SetActive(true);
        textB.gameObject.SetActive(true);
        textC.gameObject.SetActive(true);
        textAB.gameObject.SetActive(true);
        textAC.gameObject.SetActive(true);
        textBC.gameObject.SetActive(true);
        textABC.gameObject.SetActive(true);
    }
}
