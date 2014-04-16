using UnityEngine;
using System.Collections;

public class curvetest : MonoBehaviour {

    public GameObject forw;
    public GameObject anima;
    public float ttime;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

       // transform.LookAt(forw.transform.position);
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rigidbody2D.AddForce(transform.up);
            anima.animation.Play();
            ttime = ttime + Time.deltaTime*50;
            if (ttime > 0.1f)
            { 
                transform.Rotate(0, 0, 90);
                ttime = 0;
            }
         //   transform.RotateAroundLocal(new Vector3(0, 0, 1), 90);
           // anima.transform.parent = null;
        }
        if (!anima.animation.isPlaying) {
           // transform.parent = anima.transform;
            
            //transform.position = anima.transform.position;
        }
     
        //transform.position = anima.transform.position;

	}
}
