using UnityEngine;
using System.Collections;

public class carAI : car
{
    
    Transform player;
    
    // Use this for initialization
    void Start()
    {
        if (gameObject.name == "Taxi")
        {
            fspeed = 15f;
            idefence = 1;
            fattackrange = 50;
        }
        else if (gameObject.name == "Ambulance")
        {
            fspeed = 10;
            idefence = 1;
            fattackrange = 20;
        }
        else
        {
            fspeed = 5;
            idefence = 2;
            fattackrange = 80;
        }
        itemp = 0;
        player = GameObject.Find("player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.approch(transform.position,player.position))
            transform.position += transform.up*Time.deltaTime *fspeed;
        if (playercar.bbigweapon && this.approch(transform.position, player.position,fattackrange))
            Destroy(gameObject);
    }

    
   
}
