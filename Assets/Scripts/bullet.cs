using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

    float temp;
	// Use this for initialization
	void Start () {
        temp = 0;
	}
	
	// Update is called once per frame
	void Update () {
        temp += Time.deltaTime;
        if (temp >= 2f)
        {
            Destroy(gameObject);
        }
	}
}
