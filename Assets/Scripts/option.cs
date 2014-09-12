using UnityEngine;
using System.Collections;

public class option : MonoBehaviour {

    public AudioClip check;
    public bool barduino;
    public GameObject arduinodata;
    public GameObject arduinoreal;
    private Vector2 _ScreenSize = new Vector2(Screen.width,Screen.height);
    public Rect[] RectButton;
    public Texture[] texturebtn;

    void Init() 
    {
        arduinoreal = Resources.LoadAssetAtPath<GameObject>("Assets/Prefab/Arduino.prefab");
        check = Resources.LoadAssetAtPath<AudioClip>("Assets/sound/choice&enter.mp3");
        RectButton = new Rect[2];
        texturebtn = new Texture[4];
        RectButton[0] = new Rect(0.3f,0.55f,0.4f,0.2f);
        RectButton[1] = new Rect(0.3f,0.7f,0.4f,0.2f);
        texturebtn[0] = Resources.LoadAssetAtPath<Texture>("Assets/png/start game_Btn.png");
        texturebtn[1] = Resources.LoadAssetAtPath<Texture>("Assets/png/exit.png");
        texturebtn[2] = Resources.LoadAssetAtPath<Texture>("Assets/png/start game_Btnchoice.png");
        texturebtn[3] = Resources.LoadAssetAtPath<Texture>("Assets/png/exit_choice.png"); 
    }

    void Awake() {
        Init(); 
    }

	void Start () {
 
        if (barduino)
        {
            if (!GameObject.Find("Arduino"))
            {
                GameObject.Instantiate(arduinoreal).name = "Arduino";
                arduinodata = GameObject.Find("Arduino");
            }
            else
                arduinodata = GameObject.Find("Arduino");
        }
    
	}
	
	void Update ()
    {
        #region 如果Arduino存在
        if (barduino)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || arduinodata.GetComponent<SerialS>().btnstate == SerialS.BtnState.up)
            {
                if (!audio.isPlaying)
                    audio.Play();
                main.getdata._tempdata.bStart = true;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) || arduinodata.GetComponent<SerialS>().btnstate == SerialS.BtnState.down)
            {
                if (!audio.isPlaying)
                    audio.Play();
                main.getdata._tempdata.bStart = false;
            }
            if (Input.GetKeyUp(KeyCode.Space) || arduinodata.GetComponent<SerialS>().bclick)
            {
                main.bclick = true;
                audio.PlayOneShot(check);
                //if (!bStart) Application.Quit();
            }
            if (Input.GetKeyUp(KeyCode.Space) || arduinodata.GetComponent<SerialS>().bclick)
            {
                main.bclick = true;
                audio.PlayOneShot(check);
                //if (bStart) Application.LoadLevel(Application.loadedLevel + 1);
            }
        }
        #endregion
        #region PC_Keyboard
        else {
            if (Input.GetKeyDown(KeyCode.UpArrow) )
            {
                audio.Play();
                main.getdata._tempdata.bStart = true;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) )
            {
                audio.Play();
                main.getdata._tempdata.bStart = false;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                main.bclick = true;
                audio.clip = check;
                audio.Play();
            }
            else
            {
                main.bclick = false;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                main.bclick = true;
                audio.clip = check;
                audio.Play();
            }
            else
            {
                main.bclick = false;
            }
        
        }
        #endregion
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
                    if (main.getdata._tempdata.bStart)
                        GUI.DrawTexture(rect[i], texturebtn[i+2]);
                    else
                        GUI.DrawTexture(rect[i], texturebtn[i]);
                }
                else {
                    if (main.getdata._tempdata.bStart)
                        GUI.DrawTexture(rect[i], texturebtn[i]);
                    else
                        GUI.DrawTexture(rect[i], texturebtn[i+2]);
                }
            }
           
        }
        
    
    }
}
