using UnityEngine;
using System.Collections;

public class playercar : MonoBehaviour {

    public GameObject[] GOblock;
    public GameObject GObullet;
    private GameObject GObullettemp;
    private float fxtranslate,fytranslate;
    public static playerdata.Roadstate roadstate;
    public int icount;
    public static Vector2 V2carspeed;
    public static bool bcollider;
	// Use this for initialization
   
	void Start () {
	    fxtranslate = 0;
        fytranslate = 0;
        GOblock = new GameObject[10];
        for (int i = 0;i<=9 ; i++) {
            if(GameObject.Find("block" + (i + 1)))
                GOblock[i] = GameObject.Find("block" + (i + 1));
        }
        roadstate = playerdata.Roadstate.Horizon;
        bcollider = false;
	}
	
	// Update is called once per frame
    void Update()
    {
        V2carspeed = this.rigidbody2D.velocity;
        /*fxtranslate = Input.GetAxis("Horizontal") * playerdata.FHorizontalspeed*Time.deltaTime;
        fytranslate = Input.GetAxis("Vertical") * playerdata.FVerticalspeed*Time.deltaTime;*/
        //transform.Translate(fxtranslate, fytranslate, 0);
        //Debug.Log(rigidbody2D.velocity);
       #region
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rigidbody2D.AddForce(new Vector2(transform.up.x, transform.up.y) * playerdata.Fupspeed);
            }


            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                rigidbody2D.AddForce(new Vector2(-transform.up.x, -transform.up.y) * playerdata.Fupspeed);
            }


            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                rigidbody2D.AddForce(new Vector2(-transform.right.x, -transform.right.y) * playerdata.Fcurvespeed);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                rigidbody2D.AddForce(new Vector2(transform.right.x, transform.right.y) * playerdata.Fcurvespeed);
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                Debug.Log("shoot!");
                GObullettemp = (GameObject)GameObject.Instantiate(GObullet, transform.position, Quaternion.identity);
                GObullettemp.rigidbody2D.velocity = transform.up * playerdata.Fbulletforce;
            }
        }

       #endregion
        if (icount % 2 == 0)
        {
            roadstate = playerdata.Roadstate.vertical;
        }
        else
        {
            roadstate = playerdata.Roadstate.Horizon;
        }
        
    }

    void OnTriggerEnter2D(Collider2D col){
        switch(col.tag){
            case "SL":
                icount++;
                transform.Rotate(Vector3.forward, 90f);
                Destroy(col.gameObject);
                GOblock[icount-1].collider2D.isTrigger = false;
          
                break;
            case "SR":
                icount++;
                transform.Rotate(Vector3.forward, -90f);
                Destroy(col.gameObject);
                GOblock[icount-1].collider2D.isTrigger = false;
                
                break;
            case "othercar":
                rigidbody2D.velocity = Vector2.zero;
                bcollider = true;
                break;

        }
    }

}
