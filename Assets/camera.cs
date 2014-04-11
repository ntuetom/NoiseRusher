using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {

    public float Ffellowspeed;
    public Transform target;
	// Use this for initialization
	void Start () {
        transform.position = new Vector3(target.position.x,target.position.y,transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        
        if (target.position.y > -5)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), Time.deltaTime * playerdata.FCamerafellowspeed);
            transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, Time.deltaTime * playerdata.FCamerafellowspeed);
        }
	}
}
