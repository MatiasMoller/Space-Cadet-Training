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
}