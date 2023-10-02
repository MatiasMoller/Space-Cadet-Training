using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MathewHartley
{
    /// <summary>
    /// This class counts the number of targets are destroyed, releasing doors when thresholds are reached, and tracks the timer for submission to the high score table.
    /// </summary>
    public class ScoreCount : MonoBehaviour
    {
        public int targetDestroy;

        void Update()
        {
            Debug.Log("Targets Destroyed: " + targetDestroy);
        }
    }
}