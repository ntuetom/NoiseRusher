﻿using UnityEngine;
using System.Collections;

public class playerdata {

    public static int iPower = 0;
    public static float FCamerafellowspeed =2f;
    public static float Fkeyspeed = 20000;
    public static float Fspeed = 500;
    public static float Fbulletforce = 100f;
    public static bool bsuccess = false;
    public static bool bstart = false;
    public enum Roadstate { 
        vertical,
        Horizon
    }
}
