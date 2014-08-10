using UnityEngine;
using System.Collections;

public class car : MonoBehaviour{

    private float _fspeed;
    private int _idefence;
    private int _itemp;
    private float _fattackrange;

    public float fattackrange {
        get {
            return _fattackrange;
        }
        set {
            _fattackrange = value;
        }
    
    }
    public float fspeed { 
        get{
            return _fspeed;      
        }
        set {
            if (_fspeed <= 50)
                _fspeed = value;
        } 
    }
    public int idefence { 
        get {
            return _idefence;
        }
        set {
            if (_idefence <= 5)
                _idefence = value;
        } 
    }
    public int itemp {
        get {
            return _itemp;
        }
        set {
            _itemp = value;
        }
    
    }

    public car() {
        fattackrange = 100f;
    }

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
    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "bullet":
                itemp++;
                if (itemp >= idefence)
                    Destroy(gameObject);
                Destroy(col.gameObject);
                break;
            case "SL":
                transform.Rotate(Vector3.forward, 90f);
                //GOblock[icount-1].collider2D.isTrigger = false;
                break;
            case "SR":
                transform.Rotate(Vector3.forward, -90f);
                //GOblock[icount-1].collider2D.isTrigger = false;
                break;
        }
    }
    
  
}
