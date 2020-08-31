using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{

    public static void freezeTime()
    {
        Time.timeScale = 0;
    }

    public static void continueTime()
    {
        Time.timeScale = 1;
    }

    public void disableCutscene()
    {
        FindObjectOfType<PlayerMovement>().cutscene = false;
        Debug.Log("LO!");
    }


}
