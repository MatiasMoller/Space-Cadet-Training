using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MathewHartley
{
    /// <summary>
    /// This class contains a timer that can count up or down, stop at a predetermined time, be paused, and display in multiple formats.
    /// </summary>
    public class GameTimer : MonoBehaviour
    {
        [Header("Component")]
        public TextMeshProUGUI timerText;

        [Header("Timer Settings")]
        public float currentTime;
        public bool countDown = false;

        [Header("Limit Settings")]
        public bool hasLimit = false;
        public float timerLimit;

        [Header("Control Settings")]
        public bool isPaused = true;

        [Header("Format Settings")]
        public bool hasFormat;
        public TimerFormats format;
        public Dictionary<TimerFormats, string> timeFormats = new Dictionary<TimerFormats, string>();

        // Start is called before the first frame update
        //Populates the disctionary of formats
        void Start()
        {
            timeFormats.Add(TimerFormats.Whole, "0");
            timeFormats.Add(TimerFormats.TenthsDecimal, "0.0");
            timeFormats.Add(TimerFormats.HundredthsDecimal, "0.00");
            timeFormats.Add(TimerFormats.MinuteSecond, "0:00");
        }

        // Update is called once per frame
        void Update()
        {
            //checks if the timer is paused and stops increasing or decreasing if true
            if (!isPaused)
            {
                //makes timer count down is countDown bool is true, and count up if countDown bool is false
                if (countDown)
                {
                    currentTime -= Time.deltaTime;
                }
                else
                {
                    currentTime += Time.deltaTime;
                }

                //checks if a set time limit has been reached by either counting up or down locking the timer at the limit and changing the colour to red if true
                if (hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
                {
                    currentTime = timerLimit;
                    SetTimerText();
                    timerText.color = Color.red;
                    enabled = false;
                }
            }
            SetTimerText();
        }
        private void SetTimerText()
        {
            // outputs time to text box assigned to text component
            if (hasFormat)
            {
                timerText.text = currentTime.ToString(timeFormats[format]);
                //Debug.Log("Run Time: " + currentTime.ToString(timeFormats[format]));
            }
            else
            {
                timerText.text = currentTime.ToString();
                //Debug.Log("Run Time: " + currentTime.ToString());
            }
        }

        public enum TimerFormats
        {
            Whole,
            TenthsDecimal,
            HundredthsDecimal,
            MinuteSecond,
        }
    }
}