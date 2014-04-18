using UnityEngine;
using System.Collections;

public class carAI : MonoBehaviour
{
    public float fattackrange;
    Transform player;
    car ccar;
    float fspeed;
    int idefence,itemp;
    // Use this for initialization
    void Start()
    {
        if (gameObject.name == "Taxi")
        {
            fspeed = 15f;
            idefence = 1;
        }
        else if (gameObject.name == "Ambulance")
        {
            fspeed = 25;
            idefence = 1;
        }
        else
        {
            fspeed = 5;
            idefence = 2;
        }
        ccar = new car(fspeed,idefence);
        itemp = 0;
        player = GameObject.Find("player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(ccar.approch(transform.position,player.position))
            transform.position += transform.up*Time.deltaTime *ccar.fspeed;
        if (playercar.bbigweapon && ccar.approch(transform.position, player.position,fattackrange))
            Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "bullet":
                itemp++;
                if(itemp>=ccar.idefence)
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
