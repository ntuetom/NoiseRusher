using UnityEngine;
using System.Collections;

public class Data  {
    public Car_data _cardata;
    public Stage_data _stagedata;

    interface IObjdata 
    {
        void Init_value();    
    }

    public struct Car_data :IObjdata
    {
        float _fspeed;
        int _ilevel;
        int _iattack;
        int _idefence;

        public void Init_value() 
        {
            _fspeed = 10F;
            _ilevel = 1;
            _iattack = 5;
            _idefence = 5;
        }
    }

    public struct Stage_data :IObjdata
    {
        enum Stage_Level
        {
            easy, middle, hard
        };

        int _isave_stage;
        Stage_Level _istage_level;

        public void Init_value()
        {
            _isave_stage = 0;
            _istage_level = new Stage_Level();
            _istage_level = Stage_Level.easy;
        }

        public int get_isave()
        { 
            return _isave_stage; 
        } 
        
    }

    public Data()
    {
        _cardata = new Car_data();
        _cardata.Init_value();
        _stagedata = new Stage_data();
        _stagedata.Init_value();

    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
