using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerControl : MonoBehaviour
{
    public GameTimer script;
    private void OnTriggerEnter(Collider collision)
    {
        if (this.tag == "Start Timer")
        {
            script.isPaused = false;
        }
        if (this.tag == "Stop Timer")
        {
            script.hasLimit = true;
            script.timerLimit = script.currentTime;
        }
        if (this.tag == "Range Timer")
        {
            script.isPaused = false;
        }
    }
}
