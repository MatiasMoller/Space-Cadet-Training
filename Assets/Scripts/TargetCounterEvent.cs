using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCounterEvent : MonoBehaviour
{
    //This will contain the target counting event

    //THIS is the TYPE of event we will call
    public delegate void VoidDelegate();

    //THIS is the EVENT itself
    public static VoidDelegate OnTargetDeathEvent;
}
