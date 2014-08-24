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
    public bool bStart;
	// Use this for initialization

    void Init() 
    {
        check = Resources.Load<AudioClip>("choice&enter");
        RectButton = new Rect[2];
        texturebtn = new Texture[4];
        RectButton[0] = new Rect(0.3f,0.55f,0.4f,0.2f);
        RectButton[1] = new Rect(0.3f,0.7f,0.4f,0.2f);
        texturebtn[0] = Resources.Load<Texture>("start game_Btn");
        texturebtn[1] = Resources.Load<Texture>("exit.png");
        texturebtn[2] = Resources.Load<Texture>("file://" + Application.dataPath + "/png/start game_Btnchoice.png");
        texturebtn[3] = Resources.Load<Texture>("file://" + Application.dataPath + "/png/exit_choice.png"); 
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
        bStart = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (barduino)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || arduinodata.GetComponent<SerialS>().btnstate == SerialS.BtnState.up)
            {
                if (!audio.isPlaying)
                    audio.Play();
                bStart = true;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) || arduinodata.GetComponent<SerialS>().btnstate == SerialS.BtnState.down)
            {

                if (!audio.isPlaying)
                    audio.Play();
                bStart = false;
            }
            if (Input.GetKeyUp(KeyCode.Space) || arduinodata.GetComponent<SerialS>().bclick)
            {
                audio.PlayOneShot(check);
                if (!bStart) Application.Quit();
            }
            if (Input.GetKeyUp(KeyCode.Space) || arduinodata.GetComponent<SerialS>().bclick)
            {
                audio.PlayOneShot(check);
                if (bStart) Application.LoadLevel(Application.loadedLevel + 1);
            }
        }
        else {
            if (Input.GetKeyDown(KeyCode.UpArrow) )
            {
                audio.Play();
                bStart = true;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) )
            {
                audio.Play();
                bStart = false;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                audio.clip = check;
                audio.Play();
                if (!bStart) Application.Quit();
            }
            if (Input.GetKeyUp(KeyCode.Space) )
            {
                audio.clip = check;
                audio.Play();
                if (bStart) Application.LoadLevel(Application.loadedLevel + 1);
            }
        
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
