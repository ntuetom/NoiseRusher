using UnityEngine;
using System.Collections;
using System;
using System.IO.Ports;
public class SerialS : MonoBehaviour {

    public float fupdatetime;
    public float fx_axis;
    public float fy_axis;
    public float fsound;
    float ftemp;
    public string COMPort; //Com Port
    public static SerialPort stream;

	// Use this for initialization
    void Start()
    {
        stream = new SerialPort(COMPort, 9600);
        //設定傳輸速率
        stream.Open(); //Open the Serial Stream.}
        ftemp = 0;
        DontDestroyOnLoad(gameObject);
    }
	// Update is called once per frame
    void Update()
    {
        #region
        if (ftemp < fupdatetime) {
            ftemp += Time.deltaTime;
        }
        else
        {
            if (stream.IsOpen)
            {

                string value = stream.ReadLine(); //Read the information
                string[] vec3 = value.Split(',');
                if (vec3.Length >= 3)
                {
                    fx_axis = Convert.ToSingle(vec3[0]);
                    fy_axis = Convert.ToSingle(vec3[2]);
                    fsound = Convert.ToSingle(vec3[1]);
                }
                ftemp = 0;
                /*float v0;
                float.TryParse(vec3[0], out v0);
                string SendToArduino;
                if (v0 > 510)
                {
                    SendToArduino = "10";
                }
                else
                {
                    SendToArduino = "0";
                }
                stream.WriteLine(SendToArduino);*/
            }
        }
        #endregion
    }
}

