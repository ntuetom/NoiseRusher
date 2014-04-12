using UnityEngine;
using System.Collections;

public class score : MonoBehaviour {

    private Vector2 _ScreenSize = new Vector2(Screen.width, Screen.height);
    public Rect[] RectNum;
    public Texture[] Z2N;
    float icount;
	// Use this for initialization
	void Start () {
        icount = 64;
        playerdata.bstart = false;
	}
	
	// Update is called once per frame
	void Update () {
        icount -= Time.deltaTime;
        int i= (int)icount;
        //guiText.text = i.ToString();
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.LoadLevel(Application.loadedLevel-1);
        }
        if (icount <= 0)
        {
            if (playerdata.bsuccess)
            {
                Debug.Log("Good");
            }
            else
            {
                Debug.Log("Bad");
            }
        }
        else { 
            if(playerdata.bsuccess){
                Debug.Log("Good");
            }
        }
        
        
	}
    void OnGUI() {
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
                GUI.DrawTexture(rect[0], Z2N[(int)icount / 10]);
                GUI.DrawTexture(rect[1], Z2N[(int)icount % 10]);
            }
            else
            {
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
        
    }

}
