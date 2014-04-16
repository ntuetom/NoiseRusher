using UnityEngine;
using System.Collections;

public class score : MonoBehaviour {

    private Vector2 _ScreenSize = new Vector2(Screen.width, Screen.height);
    public Rect[] RectNum;
    public Rect RectEnd;
    public Texture[] Z2N;
    public Texture[] endpic;
    float icount;
    float ftemp;
	// Use this for initialization
	void Start () {
        ftemp = 0;
        icount = 64;
        playerdata.bstart = false;
        playerdata.bsuccess = false;
	}
	
	// Update is called once per frame
	void Update () {
        icount -= Time.deltaTime;
        int i= (int)icount;
        //guiText.text = i.ToString();
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.LoadLevel(Application.loadedLevel-1);
    
        }
        
        
        
	}
    void OnGUI() {
        Rect rectend = new Rect(0, 0, RectEnd.width * _ScreenSize.x, RectEnd.height * _ScreenSize.y);  
        Rect[] rect = new Rect[RectNum.Length];
        if (Z2N.Length >= 10 && RectNum.Length >= 2)
        {
            for (int i = 0; i < RectNum.Length; i++)
            {

                rect[i] = new Rect(RectNum[i].x * _ScreenSize.x
                          , RectNum[i].y * _ScreenSize.y
                          , RectNum[i].width * _ScreenSize.x
                          , RectNum[i].height * _ScreenSize.y);
            }
            if (playerdata.bstart && icount>=0)
            {
                if (audio.isPlaying)
                    audio.volume -= Time.deltaTime;
                GUI.DrawTexture(rect[0], Z2N[(int)icount / 10]);
                GUI.DrawTexture(rect[1], Z2N[(int)icount % 10]);
            }
            else
            {
                if (!audio.isPlaying)
                    audio.Play();
                if ((int)(icount % 10) == 3)
                {
                    GUI.DrawTexture(rect[2], Z2N[12]);
                }
                else if (((int)icount % 10) == 2)
                    GUI.DrawTexture(rect[2], Z2N[11]);
                else if (((int)icount % 10) == 1)
                    GUI.DrawTexture(rect[2], Z2N[10]);
                else
                    playerdata.bstart = true;
            }
            
        }

        if (icount <= 0)
        {
            if (playerdata.bsuccess)
            {
                Debug.Log("Good");
                GUI.DrawTexture(rectend,endpic[1]);
                StartCoroutine(waittime());
               // Application.LoadLevel(Application.loadedLevel - 1);
            }
            else
            {
                Debug.Log("Bad");
                GUI.DrawTexture(rectend, endpic[0]);
                StartCoroutine(waittime());
               // Application.LoadLevel(Application.loadedLevel - 1);
            }
        }
        else
        {
            if (playerdata.bsuccess)
            {
                Debug.Log("Good");
                GUI.DrawTexture(rectend, endpic[1]);
                StartCoroutine(waittime());
                /*if (ftemp >= 5f)
                    Application.LoadLevel(Application.loadedLevel - 1);
                else
                    ftemp += Time.deltaTime;*/
            }
        }
       // GUI.DrawTexture(rectend , endpic[1] );
    }

    IEnumerator waittime() {
        yield return 0;
        yield return new WaitForSeconds(5);
        Application.LoadLevel(Application.loadedLevel - 1);
    }

}
