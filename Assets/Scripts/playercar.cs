using UnityEngine;
using System.Collections;

public class playercar : MonoBehaviour {


    public AudioClip shift;
    public AudioClip accelerate;
    public AudioClip beep;
    public GameObject skidmark;
    public GameObject[] stoplight;
    public GameObject[] tire;
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
    public Sprite carlight;
    float ftiredegree =20;
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
                if (!audio.isPlaying) {
                    audio.clip = accelerate;
                    audio.Play();
                }
                //transform.position += transform.forward * Time.deltaTime *playerdata.Fupspeed;
                rigidbody2D.AddForce(new Vector2(transform.up.x, transform.up.y) * playerdata.Fspeed *Time.deltaTime);
            }


            if (Input.GetKeyDown(KeyCode.DownArrow) || arduinodata.GetComponent<SerialS>().btnstate == SerialS.BtnState.down)
            {
                //transform.position -= transform.forward * Time.deltaTime * playerdata.Fupspeed;
                rigidbody2D.AddForce(new Vector2(-transform.up.x, -transform.up.y) * playerdata.Fspeed *Time.deltaTime);
                stoplight[0].SetActive(true);
                stoplight[1].SetActive(true);
                StartCoroutine(stoplighttime());
            }


            if (Input.GetKeyDown(KeyCode.LeftArrow) || arduinodata.GetComponent<SerialS>().btnstate  == SerialS.BtnState.left)
            {
              //  transform.position -= transform.right * Time.deltaTime * playerdata.Fcurvespeed;
                //tire[0]是左輪
               
                tire[0].transform.rotation = Quaternion.Euler(0, 0,transform.eulerAngles.z+ftiredegree);
                tire[1].transform.rotation = Quaternion.Euler(0, 0,transform.eulerAngles.z+ftiredegree);
                rigidbody2D.AddForce(new Vector2(-transform.right.x, -transform.right.y) * playerdata.Fspeed *Time.deltaTime);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z + 20f)), Time.deltaTime*5f);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) || arduinodata.GetComponent<SerialS>().btnstate == SerialS.BtnState.right)
            {
               // transform.position += transform.right * Time.deltaTime * playerdata.Fcurvespeed;
                tire[0].transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z - ftiredegree);
                tire[1].transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z - ftiredegree);
                rigidbody2D.AddForce(new Vector2(transform.right.x, transform.right.y) * playerdata.Fspeed *Time.deltaTime);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z - 20f)), Time.deltaTime*5f);
            }


            if (arduinodata.GetComponent<SerialS>().btnstate == SerialS.BtnState.UR) {
                tire[0].transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z - ftiredegree);
                tire[1].transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z - ftiredegree);
                rigidbody2D.AddForce((transform.up+transform.right) * playerdata.Fspeed *Time.deltaTime);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z - 20f)), Time.deltaTime*2.5f);
            }

            if (arduinodata.GetComponent<SerialS>().btnstate == SerialS.BtnState.UL)
            {
                tire[0].transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z + ftiredegree);
                tire[1].transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z + ftiredegree);
                rigidbody2D.AddForce((transform.up-transform.right) * playerdata.Fspeed * Time.deltaTime);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z + 20f)), Time.deltaTime * 2.5f);
            }
            if (arduinodata.GetComponent<SerialS>().btnstate == SerialS.BtnState.DR)
            {
                tire[0].transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z - ftiredegree);
                tire[1].transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z - ftiredegree);
                rigidbody2D.AddForce((-transform.up+transform.right) * playerdata.Fspeed * Time.deltaTime);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z - 20f)), Time.deltaTime * 2.5f);
            }
            if (arduinodata.GetComponent<SerialS>().btnstate == SerialS.BtnState.DL)
            {
                tire[0].transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z + ftiredegree);
                tire[1].transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z + ftiredegree);
                rigidbody2D.AddForce(-(transform.up+transform.right) * playerdata.Fspeed * Time.deltaTime);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z + 20f)), Time.deltaTime * 2.5f);
            }
            
            //輪胎恢復
            if (arduinodata.GetComponent<SerialS>().btnstate == SerialS.BtnState.none) {
                tire[0].transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z);
                tire[1].transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z);
                audio.Stop();
            }

            if (Input.GetKeyUp(KeyCode.Space) || arduinodata.GetComponent<SerialS>().byell)
            {
                Debug.Log("shoot!");
                GObullettemp = (GameObject)GameObject.Instantiate(GObullet, transform.position, transform.rotation);
                GObullettemp.rigidbody2D.velocity = transform.up * playerdata.Fbulletforce;
            }
            if ((Input.GetKeyUp(KeyCode.A) || arduinodata.GetComponent<SerialS>().bclick) && playerdata.iPower >= 6)
            {
                Debug.Log("A");
                audio.PlayOneShot(beep);
                GObullettemp = (GameObject)GameObject.Instantiate(GObullet, transform.position, Quaternion.Euler(0, 0, 0));
                GObullettemp.rigidbody2D.velocity = transform.up * playerdata.Fbulletforce;
                GObullettemp = (GameObject)GameObject.Instantiate(GObullet, transform.position, Quaternion.Euler(0, 0, 180F));
                GObullettemp.rigidbody2D.velocity = -transform.up * playerdata.Fbulletforce;
                GObullettemp = (GameObject)GameObject.Instantiate(GObullet, transform.position, Quaternion.Euler(0, 0, 270F));
                GObullettemp.rigidbody2D.velocity = transform.right * playerdata.Fbulletforce;
                GObullettemp = (GameObject)GameObject.Instantiate(GObullet, transform.position, Quaternion.Euler(0, 0, 90F));
                GObullettemp.rigidbody2D.velocity = -transform.right * playerdata.Fbulletforce;
                GObullettemp = (GameObject)GameObject.Instantiate(GObullet, transform.position, Quaternion.Euler(0, 0, 45F));
                GObullettemp.rigidbody2D.velocity = (transform.up - transform.right) * playerdata.Fbulletforce;
                GObullettemp = (GameObject)GameObject.Instantiate(GObullet, transform.position, Quaternion.Euler(0, 0, 135F));
                GObullettemp.rigidbody2D.velocity = (-transform.up - transform.right) * playerdata.Fbulletforce;
                GObullettemp = (GameObject)GameObject.Instantiate(GObullet, transform.position, Quaternion.Euler(0, 0, 225F));
                GObullettemp.rigidbody2D.velocity = (-transform.up + transform.right) * playerdata.Fbulletforce;
                GObullettemp = (GameObject)GameObject.Instantiate(GObullet, transform.position, Quaternion.Euler(0, 0, 315F));
                GObullettemp.rigidbody2D.velocity = (transform.up + transform.right) * playerdata.Fbulletforce;
                //shotlight.SetActive(true);
                //StartCoroutine(casttime());
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
                if (!audio.isPlaying)
                {
                    audio.clip = accelerate;
                    audio.Play();
                }
                //transform.position += transform.forward * Time.deltaTime *playerdata.Fupspeed;
                rigidbody2D.AddForce(new Vector2(transform.up.x, transform.up.y) * playerdata.Fkeyspeed * Time.deltaTime);
            }


            if (Input.GetKeyDown(KeyCode.DownArrow) )
            {
                //transform.position -= transform.forward * Time.deltaTime * playerdata.Fupspeed;
                rigidbody2D.AddForce(new Vector2(-transform.up.x, -transform.up.y) * playerdata.Fkeyspeed * Time.deltaTime);
                stoplight[0].SetActive(true);
                stoplight[1].SetActive(true);
                StartCoroutine(stoplighttime());
            }


            if (Input.GetKeyDown(KeyCode.LeftArrow) )
            {

                tire[0].transform.Rotate(Vector3.forward, ftiredegree);
                tire[1].transform.Rotate(Vector3.forward, ftiredegree);
                
                
                //transform.position -= transform.right * Time.deltaTime * playerdata.Fcurvespeed;
                rigidbody2D.AddForce(new Vector2(-transform.right.x, -transform.right.y) * playerdata.Fkeyspeed * Time.deltaTime);
                transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.Euler(new Vector3 (0,0,transform.rotation.eulerAngles.z + 20f)),Time.deltaTime*100f);
            }
            if(Input.GetKeyUp(KeyCode.LeftArrow))
            {
                tire[0].transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z);
                tire[1].transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) )
            {

                tire[0].transform.Rotate(Vector3.forward, -ftiredegree);
                tire[1].transform.Rotate(Vector3.forward, -ftiredegree);
                
                
                //transform.position += transform.right * Time.deltaTime * playerdata.Fcurvespeed;
                rigidbody2D.AddForce(new Vector2(transform.right.x, transform.right.y) * playerdata.Fkeyspeed * Time.deltaTime);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z - 20f)), Time.deltaTime*100f);
            }
            //輪胎回復
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                tire[0].transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z);
                tire[1].transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z);
            }

            if (Input.GetKeyUp(KeyCode.Space) )
            {
                Debug.Log("shoot!");
                GObullettemp = (GameObject)GameObject.Instantiate(GObullet, transform.position, transform.rotation);
                GObullettemp.rigidbody2D.velocity = transform.up * playerdata.Fbulletforce;
            }
            if (Input.GetKeyUp(KeyCode.A) && playerdata.iPower >= 6)
            {
                Debug.Log("A");
                audio.PlayOneShot(beep);
                GObullettemp = (GameObject)GameObject.Instantiate(GObullet, transform.position, Quaternion.Euler(0, 0, 0));
                GObullettemp.rigidbody2D.velocity = transform.up * playerdata.Fbulletforce;
                GObullettemp = (GameObject)GameObject.Instantiate(GObullet, transform.position, Quaternion.Euler(0, 0, 180F));
                GObullettemp.rigidbody2D.velocity = -transform.up * playerdata.Fbulletforce;
                GObullettemp = (GameObject)GameObject.Instantiate(GObullet, transform.position, Quaternion.Euler(0, 0, 270F));
                GObullettemp.rigidbody2D.velocity = transform.right * playerdata.Fbulletforce;
                GObullettemp = (GameObject)GameObject.Instantiate(GObullet, transform.position, Quaternion.Euler(0, 0, 90F));
                GObullettemp.rigidbody2D.velocity = -transform.right * playerdata.Fbulletforce;
                GObullettemp = (GameObject)GameObject.Instantiate(GObullet, transform.position, Quaternion.Euler(0, 0, 45F));
                GObullettemp.rigidbody2D.velocity = (transform.up - transform.right) * playerdata.Fbulletforce;
                GObullettemp = (GameObject)GameObject.Instantiate(GObullet, transform.position, Quaternion.Euler(0, 0, 135F));
                GObullettemp.rigidbody2D.velocity = (-transform.up - transform.right) * playerdata.Fbulletforce;
                GObullettemp = (GameObject)GameObject.Instantiate(GObullet, transform.position, Quaternion.Euler(0, 0, 225F));
                GObullettemp.rigidbody2D.velocity = (-transform.up + transform.right) * playerdata.Fbulletforce;
                GObullettemp = (GameObject)GameObject.Instantiate(GObullet, transform.position, Quaternion.Euler(0, 0, 315F));
                GObullettemp.rigidbody2D.velocity = (transform.up + transform.right) * playerdata.Fbulletforce;
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

                shifteffect();
                //Destroy(col.gameObject);
                //GOblock[icount-1].collider2D.isTrigger = false;
                break;
            case "SR":
                icount++;
     
                shifteffect();
                //Destroy(col.gameObject);
                //GOblock[icount-1].collider2D.isTrigger = false;
                break;
            case "win":
                playerdata.bsuccess =true;
                break;
            
        }
    }

    //轉彎特效
    void shifteffect()
    {
        if (!audio.isPlaying)
        {
            audio.clip = shift;
            audio.Play();
        }
        skidmark.SetActive(true);
        StartCoroutine(skidmarktime());
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

    IEnumerator stoplighttime()
    {
        yield return 0;
        yield return new WaitForSeconds(1);
        stoplight[0].SetActive(false);
        stoplight[1].SetActive(false);
    }

    IEnumerator skidmarktime()
    {
        yield return 0;
        yield return new WaitForSeconds(2);
        skidmark.SetActive(false);
    }

}
