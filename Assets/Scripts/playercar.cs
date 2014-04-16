using UnityEngine;
using System.Collections;

public class playercar : MonoBehaviour {

    public GameObject arduinodata;
    public GameObject[] GOblock;
    public GameObject GObullet;
    private GameObject GObullettemp;
    private float fxtranslate,fytranslate;
    public static playerdata.Roadstate roadstate;
    public int icount;
    public static Vector2 V2carspeed;
    public static bool bcollider;
    public static bool bbigweapon;
    Sprite SpriteOri;
    public GameObject effect;
    public GameObject shotlight;
    public Sprite carlight;
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
        bbigweapon = false;
        V2carspeed = Vector2.zero;
        if (arduinodata = GameObject.Find("Arduino"))
        {
            arduinodata = GameObject.Find("Arduino");
            arduinodata.GetComponent<SerialS>().btnstate = SerialS.BtnState.none;
        }
        SpriteOri = gameObject.GetComponent<SpriteRenderer>().sprite;
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
        if (playerdata.bstart && arduinodata)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || arduinodata.GetComponent<SerialS>().btnstate == SerialS.BtnState.up)
            {
                //transform.position += transform.forward * Time.deltaTime *playerdata.Fupspeed;
                rigidbody2D.AddForce(new Vector2(transform.up.x, transform.up.y) * playerdata.Fspeed *Time.deltaTime);
            }


            if (Input.GetKeyDown(KeyCode.DownArrow) || arduinodata.GetComponent<SerialS>().btnstate == SerialS.BtnState.down)
            {
                //transform.position -= transform.forward * Time.deltaTime * playerdata.Fupspeed;
                rigidbody2D.AddForce(new Vector2(-transform.up.x, -transform.up.y) * playerdata.Fspeed *Time.deltaTime);
            }


            if (Input.GetKeyDown(KeyCode.LeftArrow) || arduinodata.GetComponent<SerialS>().btnstate  == SerialS.BtnState.left)
            {
              //  transform.position -= transform.right * Time.deltaTime * playerdata.Fcurvespeed;
                rigidbody2D.AddForce(new Vector2(-transform.right.x, -transform.right.y) * playerdata.Fspeed *Time.deltaTime);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) || arduinodata.GetComponent<SerialS>().btnstate == SerialS.BtnState.right)
            {
               // transform.position += transform.right * Time.deltaTime * playerdata.Fcurvespeed;
                rigidbody2D.AddForce(new Vector2(transform.right.x, transform.right.y) * playerdata.Fspeed *Time.deltaTime);
            }

            if (Input.GetKeyUp(KeyCode.Space) || arduinodata.GetComponent<SerialS>().byell)
            {
                Debug.Log("shoot!");
                GObullettemp = (GameObject)GameObject.Instantiate(GObullet, transform.position, Quaternion.identity);
                GObullettemp.rigidbody2D.velocity = transform.up * playerdata.Fbulletforce;
            }
            if ((Input.GetKeyUp(KeyCode.A) || arduinodata.GetComponent<SerialS>().bclick) && playerdata.iPower >= 6)
            {
                Debug.Log("A");
                shotlight.SetActive(true);
                StartCoroutine(casttime());
                playerdata.iPower = 0;
                bbigweapon = true;
            }
            else {
                bbigweapon = false;
            }

        }
        else if (playerdata.bstart && !arduinodata) {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                //transform.position += transform.forward * Time.deltaTime *playerdata.Fupspeed;
                rigidbody2D.AddForce(new Vector2(transform.up.x, transform.up.y) * playerdata.Fkeyspeed * Time.deltaTime);
            }


            if (Input.GetKeyDown(KeyCode.DownArrow) )
            {
                //transform.position -= transform.forward * Time.deltaTime * playerdata.Fupspeed;
                rigidbody2D.AddForce(new Vector2(-transform.up.x, -transform.up.y) * playerdata.Fkeyspeed * Time.deltaTime);
            }


            if (Input.GetKeyDown(KeyCode.LeftArrow) )
            {
                //  transform.position -= transform.right * Time.deltaTime * playerdata.Fcurvespeed;
                rigidbody2D.AddForce(new Vector2(-transform.right.x, -transform.right.y) * playerdata.Fkeyspeed * Time.deltaTime);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) )
            {
                // transform.position += transform.right * Time.deltaTime * playerdata.Fcurvespeed;
                rigidbody2D.AddForce(new Vector2(transform.right.x, transform.right.y) * playerdata.Fkeyspeed * Time.deltaTime);
            }

            if (Input.GetKeyUp(KeyCode.Space) )
            {
                Debug.Log("shoot!");
                GObullettemp = (GameObject)GameObject.Instantiate(GObullet, transform.position, Quaternion.identity);
                GObullettemp.rigidbody2D.velocity = transform.up * playerdata.Fbulletforce;
            }
            if (Input.GetKeyUp(KeyCode.A) && playerdata.iPower >= 6)
            {
                Debug.Log("A");
                shotlight.SetActive(true);
                StartCoroutine(casttime());
                playerdata.iPower = 0;
                bbigweapon = true;
            }
            else
            {
                bbigweapon = false;
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

        /*if (playerdata.iPower <=2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create(carlight.texture, SpriteOri.rect, Vector2.zero);
        }
        else {
            gameObject.GetComponent<SpriteRenderer>().sprite = SpriteOri;
        }*/
        if (playerdata.iPower >= 6f)
        {
            effect.SetActive(true);
        }
        else {
            effect.SetActive(false);
        }
     
    }

    void OnTriggerEnter2D(Collider2D col){
        switch(col.tag){
            case "SL":
                icount++;
                //rigidbody2D.velocity = Vector2.zero;
                transform.Rotate(Vector3.forward, 90f);
                Destroy(col.gameObject);
                GOblock[icount-1].collider2D.isTrigger = false;
                break;
            case "SR":
                icount++;
                //rigidbody2D.velocity = Vector2.zero;
                transform.Rotate(Vector3.forward, -90f);
                Destroy(col.gameObject);
                GOblock[icount-1].collider2D.isTrigger = false;
                break;
            case "win":
                playerdata.bsuccess =true;
                break;
            
        }
    }

    void OnCollisionEnter2D(Collision2D coll) {
        switch (coll.gameObject.tag) {
            case "othercar":
                rigidbody2D.velocity = Vector2.zero;
                bcollider = true;
                break;
            default:
                bcollider = false;
                break;
        }
    }

    IEnumerator casttime()
    {
        yield return 0;
        yield return new WaitForSeconds(3);
        shotlight.SetActive(false);
    }

}
