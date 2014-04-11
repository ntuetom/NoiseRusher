using UnityEngine;
using System.Collections;

public class carAI : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position -= transform.up;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "bullet":
                Destroy(gameObject);
                Destroy(col.gameObject);
                Debug.Log("65");
                break;
        }
    }
}
