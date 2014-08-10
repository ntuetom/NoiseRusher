using UnityEngine;
using System.Collections;

public class main : MonoBehaviour {

    void Awake() {
        GameObject.Find("Main Camera").AddComponent<option>();
    }
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
