using UnityEngine;
using System.Collections;

public class main : MonoBehaviour
{

    #region static property & variables
    public static main instance {
        get {
            if (_instance == null)
                Debug.LogError("Main null");
            return _instance;
        }
    }

    public static Data getdata 
    {
        get
        {
            return _data;
        }    
    }

    public static bool bclick {
        get 
        {
            return _bclick;        
        }
        set 
        {
            _bclick = value;
        }
    }

    private static main _instance = null;
    private static Data _data = null;
    private static MapCreator _mapcreator = null;
    private static bool _bclick;
    #endregion

    #region property & variable
    public int _istage_number;
    public int istage_number
    {
        get
        {
            return _istage_number;
        }
        set
        {
            if (value >= 0 && value <= 3)
                _istage_number = value;
        }
    }
      
    #endregion
    public delegate IEnumerator Delegate_stage();

    public Delegate_stage d_stage;
    public GameObject _startGameObject;
    void Init() 
    {
        d_stage = new Delegate_stage(EnterStage1);
        d_stage += new Delegate_stage(EnterStage2);
        _instance = this;
        _data = new Data();
        _mapcreator = new MapCreator();
        _bclick = false;
        _istage_number = 0;
        Instantiate(_startGameObject);
    }
  
    public IEnumerator EnterStage1(){       
         getdata._tempdata.async =  Application.LoadLevelAsync(Application.loadedLevel+1);
         yield return getdata._tempdata.async;          
    }
    public IEnumerator EnterStage2()
    {
        Debug.Log(main.bclick);
        yield break;
    }
    

    void Awake() {      
        Init();
        DontDestroyOnLoad(this);
    }
	// Use this for initialization
	void Start () {
        GameObject.Find("Main Camera").AddComponent<option>();
	}
	
	// Update is called once per frame
	void Update () {
        if(bclick)
        {
            if (getdata._tempdata.bStart)
                StartCoroutine(d_stage.Invoke());
            else
                Application.Quit();
        }
        /*int progerss = (int)getdata._tempdata.async.progress * 100;
        Debug.Log(progerss);*/
	}
}
