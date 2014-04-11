using UnityEngine;
using System.Collections;

public class score : MonoBehaviour {

    float icount;
	// Use this for initialization
	void Start () {
        icount = 60;
	}
	
	// Update is called once per frame
	void Update () {
        icount -= Time.deltaTime;
        int i= (int)icount;
        guiText.text = i.ToString();

        
	}

}
