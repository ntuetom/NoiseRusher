using UnityEngine;
using System.Collections;

public class option : MonoBehaviour {

    private Vector2 _ScreenSize = new Vector2(Screen.width,Screen.height);
    public Rect[] RectButton;
    public Texture[] texturebtn;
    public bool bStart;
	// Use this for initialization
	void Start () {
        bStart = true;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            bStart = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            bStart = false;
        }
        if (Input.GetKeyUp(KeyCode.Space))
            if(!bStart)Application.Quit();
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if(bStart)Application.LoadLevel(Application.loadedLevel+1);
        }
	}

    void OnGUI() {
        
        Rect[] rect = new Rect[2];
        if(RectButton.Length>=2){
            for (int i = 0; i <= 1; i++)
            {
            
                rect[i] = new Rect(RectButton[i].x * _ScreenSize.x
                                , RectButton[i].y * _ScreenSize.y
                                , RectButton[i].width * _ScreenSize.x
                                , RectButton[i].height * _ScreenSize.y);
                if (i == 0)
                {
                    if (bStart)
                        GUI.DrawTexture(rect[i], texturebtn[i+2]);
                    else
                        GUI.DrawTexture(rect[i], texturebtn[i]);
                }
                else {
                    if (bStart)
                        GUI.DrawTexture(rect[i], texturebtn[i]);
                    else
                        GUI.DrawTexture(rect[i], texturebtn[i+2]);
                }
            }
           
        }
        
    
    }
}
