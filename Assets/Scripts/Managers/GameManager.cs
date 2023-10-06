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

        public void DoorsOpened()
        {
            // You can add any logic here related to doors being opened.
            // For example, you might want to trigger something when doors are opened.
            Debug.Log("Doors are opened!");
        }
    }
}
