using UnityEngine;
using System.Collections;

public class powertexture : MonoBehaviour {

    private Vector2 _ScreenSize = new Vector2(Screen.width, Screen.height);
    public Texture power;
    public Texture energy;
    public Rect powerrect;
    public float fgaintime;
    float ftemptime;
    bool bistop;
	// Use this for initialization
	void Start () {
        playerdata.iPower = 0;
	}
	
	// Update is called once per frame
    void Update()
    {
        ftemptime += Time.deltaTime;
        if (ftemptime >= fgaintime)
        {
            if (playerdata.iPower < 6)
                playerdata.iPower++;
           
            ftemptime = 0;
        }
        if ((playercar.bcollider || playercar.V2carspeed == Vector2.zero )  && playerdata.iPower > 0 && !bistop)
        {
            playerdata.iPower--;
        }
        
        if (playercar.V2carspeed != Vector2.zero)
        {
            bistop = false;
        }
    }
    void OnGUI() {
        GUI.color = Color.red;
        Rect rect = new Rect((powerrect.x+0.02f) * _ScreenSize.x
                              , (powerrect.y+0.495f) * _ScreenSize.y
                              , powerrect.width/2 * _ScreenSize.x
                              , (-powerrect.height / 6.5f) * playerdata.iPower * _ScreenSize.y);
        GUI.DrawTexture(rect, energy);
        GUI.color = Color.white;
        Rect rect1 = new Rect(powerrect.x * _ScreenSize.x
                              , powerrect.y * _ScreenSize.y
                              , powerrect.width * _ScreenSize.x
                              , powerrect.height * _ScreenSize.y);
        GUI.DrawTexture(rect1, power);
       
        
    
    }
}
