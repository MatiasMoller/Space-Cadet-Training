using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopClock : MonoBehaviour
{
    public Timer script;
    private void OnTriggerEnter(Collider collision)
    {
        script.hasLimit = true;
        script.timerLimit = script.currentTime;

    }
}
