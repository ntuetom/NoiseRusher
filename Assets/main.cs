using UnityEngine;
using System.Collections;

public class main : MonoBehaviour
{

    #region property & variables
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

    public static int istage {
        get 
        {
            return _istage;
        }
        set 
        {
            if (value >= 0 && value <= 3)
                _istage = value;
        }
    }

    public static bool bchange {
        get 
        {
            return _bchange;        
        }
    }

    private static main _instance = null;
    private static Data _data = null;
    private static int _istage;
    private static bool _bchange;

    #endregion

    public GameObject _startGameObject;
    void Init() 
    {
        _instance = this;
        _data = new Data();
        _bchange = false;
        _istage = 0;
        Instantiate(_startGameObject);
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
	    
	}
}
