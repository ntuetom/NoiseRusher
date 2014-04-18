using UnityEngine;
using System.Collections;

public class wave : MonoBehaviour {

    float middletime = 2f;
    float changetime = 4f;
    float ftemp;
	// Use this for initialization
	void Start () {
	    ftemp = 0;
	}
	
	// Update is called once per frame
	void Update () {
        ftemp += Time.deltaTime;
        if(ftemp>=changetime){
            ftemp = 0;
        }
        else if(ftemp>=middletime){
            transform.Translate(transform.right * Time.deltaTime);
        }
        else{
            transform.Translate(-transform.right * Time.deltaTime);
        }
	}

    IEnumerator otherside() {
        yield return 0;
        yield return new WaitForSeconds(2);
        transform.Translate(transform.right * Time.deltaTime);
        
    }
    IEnumerator side()
    {
        yield return 0;
        yield return new WaitForSeconds(2);
        transform.Translate(-transform.right * Time.deltaTime);
    }

}
