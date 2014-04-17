using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {

    public float Ffellowspeed;
    public GameObject target;
    
	// Use this for initialization
	void Start () {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x, target.transform.position.y, transform.transform.position.z), Time.deltaTime * playerdata.FCamerafellowspeed);
        
	}
	
	// Update is called once per frame
	void Update () {


        if (playerdata.bstart && !audio.isPlaying) {
            audio.Play();
        }
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), Time.deltaTime * playerdata.FCamerafellowspeed);
        //if(target.position.y>=-5)
       /* if (playercar.roadstate == playerdata.Roadstate.vertical)
        {
            //向後開
            if (target.GetComponent<playercar>().icount == 2 || target.GetComponent<playercar>().icount == 10)
                transform.position = new Vector3(transform.position.x, target.transform.position.y - 5F, transform.position.z);
            //向前開
            else               
                transform.position = new Vector3(transform.position.x, target.transform.position.y + 5F, transform.position.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, target.transform.rotation, Time.deltaTime * playerdata.FCamerafellowspeed);
        }
        else
        {
            //向右開
            if (target.GetComponent<playercar>().icount == 7 || target.GetComponent<playercar>().icount == 9)
                transform.position = new Vector3(target.transform.position.x + 5F, transform.position.y, transform.position.z);
            //向左開
            else
                transform.position = new Vector3(target.transform.position.x - 5F, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, target.transform.rotation, Time.deltaTime * playerdata.FCamerafellowspeed);
        }*/
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y , transform.position.z);
        if (target.transform.rotation.eulerAngles.z >= 60f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, target.transform.rotation, Time.deltaTime * playerdata.FCamerafellowspeed);
        }
	}
}
