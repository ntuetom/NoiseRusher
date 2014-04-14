using UnityEngine;
using System.Collections;
using System;
using System.IO.Ports;
using System.Threading;
public class SerialS : MonoBehaviour {

    public enum BtnState
    {
        up,down,left,right,none
    };
    public float fupdatetime;
    public float fx_axis;
    public float fy_axis;
    public float fsound;
    public float fbtn;
    public string COMPort; //Com Port
    public SerialPort stream;
    public BtnState btnstate;
    public bool byell;
    public bool bclick;
    float ftemp=0;
    Thread myThread;

	// Use this for initialization
    void Start()
    {
        /*stream = new SerialPort(COMPort, 19200);
        stream.Open();
        btnstate = BtnState.none;
        //stream.ReadTimeout = 10;*/
        /*try
        {
            stream.Open(); //Open the Serial Stream.
            stream.DataReceived += DataReceivedHandler;
            stream.ErrorReceived += DataErrorReceivedHandler;
        }
        catch (Exception e) {
            Debug.Log("Could not open serial port: " + e.Message);
        }*/
        myThread = new Thread(new ThreadStart(GetArduino));
        myThread.Start();
        DontDestroyOnLoad(gameObject);
        byell = false;
    }

    private void GetArduino() {
        stream = new SerialPort(COMPort, 19200);
        stream.Open();
        while (myThread.IsAlive) {
            
            string value = stream.ReadLine(); //Read the information
            string[] vec3 = value.Split(',');
            if (vec3.Length >= 4)
            {
                fx_axis = Convert.ToSingle(vec3[0]);
                fy_axis = Convert.ToSingle(vec3[1]);
                fsound = Convert.ToSingle(vec3[2]);
                fbtn = Convert.ToSingle(vec3[3]);
            }
                
        }


    }

    void nothread() {
        string value = stream.ReadLine(); //Read the information
        string[] vec3 = value.Split(',');
        if (vec3.Length >= 4)
        {
            fx_axis = Convert.ToSingle(vec3[0]);
            fy_axis = Convert.ToSingle(vec3[1]);
            fsound = Convert.ToSingle(vec3[2]);
            fbtn = Convert.ToSingle(vec3[3]);
        }
    
    }
	// Update is called once per frame
    void Update()
    {
        /*if (ftemp < fupdatetime) { 
            ftemp+=Time.deltaTime;
        }
        else{
            nothread();
            ftemp = 0;
        }*/

        if (fx_axis >= 600f)
            btnstate = BtnState.up;
        else if (fx_axis <= 400f)
            btnstate = BtnState.down;
        else if (fy_axis >= 600f)
            btnstate = BtnState.right;
        else if (fy_axis <= 400f)
            btnstate = BtnState.left;
        else
            btnstate = BtnState.none;
        if (fsound > 42f)
            byell = true;
        else
            byell = false;
        if (fbtn == 1)
            bclick = true;
        else
            bclick = false;
    }
    /*
    void OnApplicationQuit()
    {
        if (myThread.IsAlive)
        {
            myThread.Abort();
            myThread.Join();
        }
        
    }

    void OnDestory()
    {
        if (myThread.IsAlive)
        {
            myThread.Abort();
            myThread.Join();
        }

    }

    /*private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e) {
        SerialPort sp = (SerialPort)sender;
        string value = sp.ReadLine(); //Read the information
        string[] vec3 = value.Split(',');
        if (vec3.Length >= 3)
        {
            fx_axis = Convert.ToSingle(vec3[0]);
            fy_axis = Convert.ToSingle(vec3[2]);
            fsound = Convert.ToSingle(vec3[1]);
        }
        Debug.Log(fx_axis+" "+fy_axis+" "+fsound);
    }

    private void DataErrorReceivedHandler(object sender, 
                                          SerialErrorReceivedEventArgs e)
    {
        Debug.Log("Serial port error:" +e.EventType.ToString ("G"));            
    }*/
}

