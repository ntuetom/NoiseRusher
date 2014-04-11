using UnityEngine;
using System.Collections;

public class playercar : MonoBehaviour {

    public GameObject GObullet;
    private GameObject GObullettemp;
    private float fxtranslate,fytranslate;
	// Use this for initialization
   
	void Start () {
	    fxtranslate = 0;
        fytranslate = 0;
	}
	
	// Update is called once per frame
	void Update () {
        fxtranslate = Input.GetAxis("Horizontal") * playerdata.FHorizontalspeed*Time.deltaTime;
        fytranslate = Input.GetAxis("Vertical") * playerdata.FVerticalspeed*Time.deltaTime;

        transform.Translate(fxtranslate, fytranslate, 0);
        if (Input.GetKeyUp(KeyCode.Space)) {
            Debug.Log("shoot!");
            GObullettemp = (GameObject)GameObject.Instantiate(GObullet,transform.position,Quaternion.identity);
            GObullettemp.rigidbody.velocity = transform.up * playerdata.Fbulletforce ;
        }
	}

    void OnTriggerEnter2D(Collider2D col){
        switch(col.name){
            case "swervezoneL":
                transform.Rotate(Vector3.forward, 90f);
                Destroy(col.gameObject);
                Debug.Log("swerve");
                break;
            case "swervezoneR":
                transform.Rotate(Vector3.forward, -90f);
                Destroy(col.gameObject);
                Debug.Log("swerve");
                break;
    
        }
    }
}
