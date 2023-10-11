using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MathewHartley
{
    /// <summary>
    /// This class applies gameplay controls to the timer, starting, stopping and pausing it based on which trigger is activated.
    /// </summary>
    public class TimerControl : MonoBehaviour
    {

    public GameTimer timer;
        private void OnTriggerEnter(Collider collision)
        {
            if (this.tag == "Start Timer")
            {
                timer.isPaused = false;
            }
            if (this.tag == "Stop Timer")
            {
                timer.hasLimit = true;
                timer.timerLimit = timer.currentTime;
            }
            if (this.tag == "Range Timer")
            {
                timer.isPaused = false;
            }
        }
    }
}