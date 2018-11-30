﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Data : MonoBehaviour
{

    public bool isArcade;

    const string PREFAB_PATH = "Data";
    
    static Data mInstance = null;
	public Settings settings;
	public ModulesManager modulesManager;
	public ExternalTexts externalTexts;
	public PlayerData playerData;
	public LevelsData levelData;
	public InterfaceSfx interfaceSfx;

	public static Data Instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = FindObjectOfType<Data>();

                if (mInstance == null)
                {
                    GameObject go = Instantiate(Resources.Load<GameObject>(PREFAB_PATH)) as GameObject;
                    mInstance = go.GetComponent<Data>();
                }
            }
            return mInstance;
        }
    }
    public string currentLevel;
    public void LoadScene(string aLevelName)
    {
        this.currentLevel = aLevelName;
        Time.timeScale = 1;
        SceneManager.LoadScene(aLevelName);
    }

    void Awake()
    {
		QualitySettings.vSyncCount = 1;

        if (!mInstance)
            mInstance = this;
        else
        {
            Destroy(this.gameObject);
            return;
        }
        if(isArcade)
            Cursor.visible = false;

        DontDestroyOnLoad(this.gameObject);

		settings = GetComponent<Settings> ();
		modulesManager = GetComponent<ModulesManager> ();
		externalTexts = GetComponent<ExternalTexts> ();
		playerData = GetComponent<PlayerData> ();
		levelData = GetComponent<LevelsData> ();
		interfaceSfx = GetComponent<InterfaceSfx> ();

		//PlayerPrefs.DeleteAll ();

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Application.Quit();
        }
    }
}
