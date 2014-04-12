using UnityEngine;
using System.Collections;

public class playerdata {

    public static int iPower = 0;
    public static float FCamerafellowspeed =5f;
    public static float Fupspeed = 300;
    public static float Fcurvespeed = 100;
    public static float Fbulletforce = 100f;
    public static bool bsuccess = false;
    public static bool bstart = false;
    public enum Roadstate { 
        vertical,
        Horizon
    }
}
