﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trivia : MonoBehaviour {
    public Text moduleField;
    public Text title;
    public Tween popupPregunta;
    public ResultButton resultButton_to_instantiate;
    public Transform buttonsContainer;
    public Image puntos;
    public Text NumPregunta;
    public Text debug;
    public GameObject levelSelector;
    public GameObject modeSelector;
    public GameObject menu;
    public GameObject creditos;
    public GameObject rightFX;
    public GameObject winFX;
    public GameObject comboFX;
    public GameObject combo;
    public Text comboText;
    public GameObject levelCompleteSign;
    public InputField id;
    public InputField nombre;
    public Button login;
    public GameObject noLogin;

    AudioSource audiosource;

    Tween preguntaTween, buttonsTween, nroTween;

    ModulesManager modulesManager;

    int nPregunta;

    int comboCount;
    bool isCombo;

    GameObject titleClone, titleCloneUp, titleCloneDown;

    void Start() {
        audiosource = GetComponent<AudioSource>();
        modulesManager = Data.Instance.modulesManager;
        Events.NextExercise += NextExercise;
        Events.AddScore += AddScore;
        Events.BadAnswer += BadAnswer;
        Events.AreaChange += AreaChange;
        Events.ReplayArea += AreaChange;
        Events.ShowLevelSelector += ShowLevelSelector;
        Events.ShowLevelMenu += ShowMenu;
        Events.SetTitleDenom += SetTitleDenom;
        Events.SetTitleDenomUp += SetTitleDenomUp;
        Events.SetTitleDenomDown += SetTitleDenomDown;

        LevelsData.Level l = Data.Instance.levelData.CurrentLevel;
        puntos.fillAmount = 1f * l.localPoints / l.length;

        nPregunta = Data.Instance.levelData.triviaCount;

        preguntaTween = title.gameObject.GetComponent<Tween>();
        buttonsTween = buttonsContainer.GetComponent<Tween>();
        nroTween = NumPregunta.GetComponentInParent<Tween>();

        if (Data.Instance.playerData.mode < 0)
            ShowModeSelector(true);
        else if (!Data.Instance.levelData.allAreasCompleted || Data.Instance.levelData.replay) {
            if (Data.Instance.settings.GetActualRecorrido().ejercicios.exercises.Count > 0)
                NextExercise();
            else
                Invoke("NextExercise", 1);
        } else {
            ShowLevelSelector(true);
        }

        ShowLogin();
    }

    void OnDestroy() {
        Events.NextExercise -= NextExercise;
        Events.AddScore -= AddScore;
        Events.AreaChange -= AreaChange;
        Events.ReplayArea -= AreaChange;
        Events.BadAnswer -= BadAnswer;
        Events.ShowLevelSelector -= ShowLevelSelector;
        Events.ShowLevelMenu -= ShowMenu;
        Events.SetTitleDenom -= SetTitleDenom;
        Events.SetTitleDenomUp -= SetTitleDenomUp;
        Events.SetTitleDenomDown -= SetTitleDenomDown;
    }

    public void PrevModule() {
        modulesManager.moduleIndex--;
        if (modulesManager.moduleIndex < 0)
            modulesManager.moduleIndex = 0;
        CreateNewModule();
    }
    public void NextModule() {
        modulesManager.moduleIndex++;
        if (modulesManager.moduleIndex >= Data.Instance.settings.GetActualRecorrido().ejercicios.exercises.Count - 1)
            modulesManager.moduleIndex = Data.Instance.settings.GetActualRecorrido().ejercicios.exercises.Count - 1;
        CreateNewModule();
    }

    public void NextExercise() {
        Data.Instance.levelData.AddTriviaCount();
        nPregunta++;
        NumPregunta.text = "" + nPregunta;
        modulesManager.moduleIndex++;
        if (modulesManager.moduleIndex > Data.Instance.settings.GetActualRecorrido().ejercicios.exercises.Count - 1)
            modulesManager.moduleIndex = 0;
        CreateNewModule();
    }

    public void CreateNewModule() {
        ShowQuestions(true);
        modulesManager.SetNewModuleActive();
        moduleField.text = "MODULE " + modulesManager.actualModule.module;
        title.text = modulesManager.actualModule.title;
        debug.text = modulesManager.actualModule.data.title.Replace('#', ' ');
        Utils.RemoveAllChildsIn(buttonsContainer);
        audiosource.Play();
        for (int i = 0; i < modulesManager.actualModule.results.Count; i++) {
            ResultButton button = Instantiate(resultButton_to_instantiate);
            button.transform.SetParent(buttonsContainer);
            button.transform.localScale = Vector3.one;
            button.Init(modulesManager.actualModule.values[i], i);
        }
        ShuffleChildOrder(buttonsContainer);
    }

    void SetTitleDenom(string t) {
        titleClone = GameObject.Instantiate(title.gameObject);
        titleClone.transform.parent = title.transform.parent;
        titleClone.transform.SetAsFirstSibling();
        Text text = titleClone.GetComponent<Text>();
        text.rectTransform.localPosition = new Vector3(title.rectTransform.localPosition.x, title.rectTransform.localPosition.y + 40, title.rectTransform.localPosition.z);
        text.text = t;
    }

    void SetTitleDenomUp(string t) {
        titleCloneUp = GameObject.Instantiate(title.gameObject);
        titleCloneUp.transform.parent = title.transform.parent;
        titleCloneUp.transform.SetAsFirstSibling();
        Text text = titleCloneUp.GetComponent<Text>();
        text.rectTransform.localPosition = new Vector3(title.rectTransform.localPosition.x, title.rectTransform.localPosition.y + 80, title.rectTransform.localPosition.z);
        text.text = t;
    }

    void SetTitleDenomDown(string t) {
        titleCloneDown = GameObject.Instantiate(title.gameObject);
        titleCloneDown.transform.parent = title.transform.parent;
        titleCloneDown.transform.SetAsLastSibling();
        Text text = titleCloneDown.GetComponent<Text>();
        text.rectTransform.localPosition = new Vector3(title.rectTransform.localPosition.x, title.rectTransform.localPosition.y - 50, title.rectTransform.localPosition.z);
        text.text = t;
    }

    void ClearTitleDenom() {
        Destroy(titleClone);
        Destroy(titleCloneDown);
        Destroy(titleCloneUp);
    }

    void ShowQuestions(bool enable) {
        buttonsTween.reverse = !enable;
        buttonsTween.doTween = true;
        preguntaTween.reverse = !enable;
        preguntaTween.doTween = true;
        popupPregunta.reverse = !enable;
        popupPregunta.doTween = true;
        nroTween.reverse = !enable;
        nroTween.doTween = true;
    }

    void HideQuestions() {
        ShowQuestions(false);
        ClearTitleDenom();
    }

    public void ShuffleChildOrder(Transform container) {
        for (int i = 0; i < container.childCount; i++) {
            Transform t = container.GetChild(i);
            if (Random.value < 0.3f)
                t.transform.SetAsFirstSibling();
            else if (Random.value < 0.6)
                t.transform.SetAsLastSibling();
        }
    }

    public void ShowLevelSelector(bool enable) {
        Data.Instance.interfaceSfx.ClickSfx(1.1f);
        levelSelector.SetActive(enable);
        if (enable) {
            menu.SetActive(false);
            creditos.SetActive(false);
        }
    }

    public void ShowModeSelector(bool enable) {
        Data.Instance.interfaceSfx.ClickSfx(1.1f);
        modeSelector.SetActive(enable);
        if (enable) {
            menu.SetActive(false);
            creditos.SetActive(false);
        }
    }

    public void ShowMenu(bool enable) {
        menu.SetActive(enable);
        Data.Instance.interfaceSfx.ClickSfx(0.9f);
        if (enable) {
            levelSelector.SetActive(false);
            creditos.SetActive(false);
        }
    }

    public void ShowCredits(bool enable) {
        if (enable)
            Data.Instance.interfaceSfx.ClickSfx(1.2f);
        creditos.SetActive(enable);
    }

    void AreaChange(int i) {
        LevelsData.Level l = Data.Instance.levelData.CurrentLevel;
        puntos.fillAmount = 1f * l.localPoints / l.length;
    }

    void BadAnswer() {
        comboCount = 0;
        Invoke("HideQuestions", 1);
    }

    void AddScore() {
        Invoke("HideQuestions", 1);
        puntos.fillAmount += (1f / Data.Instance.levelData.CurrentLevel.length);
        comboCount++;
        if (puntos.fillAmount > 0.98f) {
            OnWin();
        } else {
            rightFX.SetActive(true);
            Invoke("CloseRFx", 2f);
        }
    }

    void OnWin() {
        Data.Instance.interfaceSfx.WinLevelSfx();
        winFX.SetActive(true);
        levelCompleteSign.SetActive(true);
        Data.Instance.levelData.AddStars();
        Invoke("CloseWFx", 4f);
    }

    void CloseRFx() {
        rightFX.SetActive(false);
        Debug.Log("CloseRFX");
        if (Data.Instance.levelData.CurrentLevel.comboReward > 0 && comboCount >= Data.Instance.levelData.CurrentLevel.comboCondition) {
            Data.Instance.interfaceSfx.ComboSfx();
            puntos.fillAmount += (Data.Instance.levelData.CurrentLevel.comboReward * 1f / Data.Instance.levelData.CurrentLevel.length);
            Data.Instance.playerData.AddScore(Data.Instance.levelData.CurrentLevel.comboReward);
            comboFX.SetActive(true);
            combo.SetActive(true);
            comboText.text = "+" + Data.Instance.levelData.CurrentLevel.comboReward;
            comboCount = 0;
            isCombo = true;
            Invoke("CloseComboFx", 2f);
        } else {
            Data.Instance.levelData.SetLevel();
            Events.NextExercise();
        }
    }

    void CloseComboFx() {
        comboFX.SetActive(false);
        combo.SetActive(false);
        if (puntos.fillAmount > 0.98f) {
            OnWin();
        } else {
            Data.Instance.levelData.SetLevel(Data.Instance.levelData.CurrentLevel.comboReward + 1);
            Events.NextExercise();
            isCombo = false;
        }
    }

    void CloseWFx() {
        winFX.SetActive(false);
        levelCompleteSign.SetActive(false);
        Debug.Log("CloseWFX");
        if (isCombo == false)
            Data.Instance.levelData.SetLevel();
        else {
            Data.Instance.levelData.SetLevel(Data.Instance.levelData.CurrentLevel.comboReward + 1);
            isCombo = false;
        }
        //Events.NextExercise ();
    }

    public void SelectArea(int id) {
        Events.ReplayArea(id);
        levelSelector.SetActive(false);
        Events.NextExercise();
    }

    void ShowLogin() {
        Debug.Log("Alumno: " + Data.Instance.esAlumno);
        if (Data.Instance.esAlumno && Data.Instance.firebaseInitialized) {
            id.text = PlayerPrefs.GetString("id");
            nombre.text = PlayerPrefs.GetString("nombre");
        }

        id.interactable = !Data.Instance.esAlumno;
        nombre.interactable = !Data.Instance.esAlumno;
        login.interactable = !Data.Instance.esAlumno;
    }

    public void Register() {
        bool val = Data.Instance.users.IsUser(id.text, nombre.text);
        ShowLogin();
        if (!val) {
            noLogin.SetActive(true);
            Invoke("HideMessage", 3);
        }
    }

    void HideMessage() {
        id.text = "";
        nombre.text = "";
        noLogin.SetActive(false);
    }
}