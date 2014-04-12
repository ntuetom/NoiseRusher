using UnityEngine;
using System.Collections;

public class car{

    public float fspeed { get; set; }
    public int idefence { get; set; }

    public car(float _speed,int _defence){
        fspeed = _speed;
        idefence = _defence;
    }

    public void move() { 
        
    }
    public bool approch(Vector3 car,Vector3 player) {
        if (Vector3.Distance(car, player) <= 30f)
            return true;
        else 
            return false;
    }

    public bool approch(Vector3 car,Vector3 player,float frange) {
        if (Vector3.Distance(car, player) <= frange)
            return true;
        else 
            return false;
    }

    
  
}
