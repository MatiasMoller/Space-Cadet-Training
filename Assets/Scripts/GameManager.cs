using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MathewHartley
{
    public class GameManager : MonoBehaviour
    {
        public TextMeshProUGUI killCountTxt;
        public int killCount;

        public void TargetDestroyed()
        {
            killCount++;
            killCountTxt.text = killCount.ToString();
        }

    }
}