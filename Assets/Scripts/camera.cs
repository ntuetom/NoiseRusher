using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {

    public float Ffellowspeed;
    public Transform target;
    
	// Use this for initialization
	void Start () {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), Time.deltaTime * playerdata.FCamerafellowspeed);
        
	}
	
	// Update is called once per frame
	void Update () {
        
       
        
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), Time.deltaTime * playerdata.FCamerafellowspeed);
        if(target.position.y>=-5)
        if (playercar.roadstate == playerdata.Roadstate.vertical)
        {
            transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, Time.deltaTime * playerdata.FCamerafellowspeed);
        }
        else
        {
            transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, Time.deltaTime * playerdata.FCamerafellowspeed);
        }
        
	}
}
