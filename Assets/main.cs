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

    public static bool bchange {
        get 
        {
            return _bchange;        
        }
    }

    private static main _instance = null;
    private static Data _data = null;
    private static MapCreator _mapcreator = null;
    private static bool _bchange;
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

    public GameObject _startGameObject;
    void Init() 
    {
        _instance = this;
        _data = new Data();
        _mapcreator = new MapCreator();
        _bchange = false;
        _istage_number = 0;
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
        if (_bchange) { 
        
        }
	}
}
