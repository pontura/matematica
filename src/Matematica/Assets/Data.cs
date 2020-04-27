using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;
using System.Threading.Tasks;
using Firebase;
using Firebase.Analytics;


public class Data : MonoBehaviour
{
    public bool resetData;
    public bool isArcade;

    const string PREFAB_PATH = "Data";
    
    static Data mInstance = null;
	public Settings settings;
	public ModulesManager modulesManager;
	public ExternalTexts externalTexts;
	public PlayerData playerData;
	public LevelsData levelData;
	public InterfaceSfx interfaceSfx;
	public Users users;
	public bool esAlumno;
	public Firebase.FirebaseApp app;

    public bool firebaseInitialized;

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
		app = null;

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
		users = GetComponent<Users> ();

        if(resetData)
            PlayerPrefs.DeleteAll ();

        int val = PlayerPrefs.GetInt ("user");
		Debug.Log (val);

		if (val > 0)
			Data.Instance.esAlumno = true;


        if (esAlumno)
            FBase_Login(false);
		

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Application.Quit();
        }
    }

    public void FBase_Login(bool firstLogin)
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                //app = Firebase.FirebaseApp.DefaultInstance;
                InitializeFirebase(firstLogin);

                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                Debug.LogError(System.String.Format(
                    "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
    }

    void InitializeFirebase(bool firstLogin)
    {
        Debug.Log("Enabling data collection.");
        FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);

        Debug.Log("Set user properties.");
        // Set the user's sign up method.
        FirebaseAnalytics.SetUserProperty(
          FirebaseAnalytics.UserPropertySignUpMethod,
          "Google");
        // Set the user ID.
        FirebaseAnalytics.SetUserId(SystemInfo.deviceUniqueIdentifier);
        
        // Set default session duration values.
        FirebaseAnalytics.SetMinimumSessionDuration(new TimeSpan(0, 0, 10));
        FirebaseAnalytics.SetSessionTimeoutDuration(new TimeSpan(0, 30, 0));
        firebaseInitialized = true;

        Debug.Log("Logging a login event.");
        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLogin);

        if (firstLogin)
        {
            Firebase.Analytics.FirebaseAnalytics.LogEvent(
               Firebase.Analytics.FirebaseAnalytics.EventTutorialBegin, new Firebase.Analytics.Parameter(Firebase.Analytics.FirebaseAnalytics.ParameterCreativeName,
                   "JUEGO INICIADO&preguntas:0"));
        }
    }
}
