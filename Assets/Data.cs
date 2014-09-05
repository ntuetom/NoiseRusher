using UnityEngine;
using System.Collections;

public class Data  {
    public Car_data _cardata;
    public Stage_data _stagedata;
    public Temp_data _tempdata;

    interface IObjdata 
    {
       void Init_value();    
    }

    public struct Car_data :IObjdata
    {
        float _fSpeed;
        int _iPower;
        int _iLevel;
        int _iAttack;
        int _iDefence;
        int _iBullet_Force;

        public void Init_value() 
        {
            _fSpeed = 2000F;
            _iLevel = 1;
            _iAttack = 5;
            _iDefence = 5;
            _iPower = 0;
            _iBullet_Force = 60;
        }
    }

    public struct Stage_data :IObjdata
    {
        enum Stage_Level
        {
            easy, middle, hard
        };

        int _iSave_Stage;
        int _iCamera_Speed;
        Stage_Level _enumStage_Level;

        public void Init_value()
        {
            _iSave_Stage = 0;
            _enumStage_Level = new Stage_Level();
            _iCamera_Speed = 2;
            _enumStage_Level = Stage_Level.easy;
        }

        public int get_isave()
        { 
            return _iSave_Stage; 
        } 
        
    }

    public struct Temp_data : IObjdata 
    {
        public enum Roadstate
        {
            vertical,
            Horizon,
            none
        }
        Roadstate _enumRoad_State;
        //用於關卡
        public bool _bSuccess;
        //用於選單
        public bool _bStart;

        bool bSuccess {
            get {
                return _bSuccess;
            }
            set {
                _bSuccess = value;
            }
        }

        bool bStart {
            get { 
                return _bStart;
            }
            set {
                _bStart = value;
            }
        }

        public void Init_value()
        {
            _enumRoad_State = new Roadstate;
            _enumRoad_State = Roadstate.none;
            _bStart = true;
            _bSuccess = false;
        }
    }

    public Data()
    {
        _cardata = new Car_data();
        _cardata.Init_value();
        _stagedata = new Stage_data();
        _stagedata.Init_value();
        _tempdata = new Temp_data();
        _tempdata.Init_value();
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
