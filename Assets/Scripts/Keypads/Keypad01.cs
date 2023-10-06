using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MathewHartley
{
    public class Keypad : Interactable
    {
        MathewHartley.GameManager gameManagerScript;
        [SerializeField] private GameObject door1;
        private bool doorOpen;
        void Start()
        {
            gameManagerScript = FindObjectOfType<GameManager>();
            if (gameManagerScript == null)
            {
                Debug.LogError("GameManager not found in the scene!");
            }
            else
            {
                Debug.Log("GameManager found: " + gameManagerScript.name);
            }
        }

        protected override void Interact()
        {
            if (gameManagerScript != null && gameManagerScript.killCount > 9)
            {
                doorOpen = !doorOpen;
                door1.GetComponent<Animator>().SetBool("IsOpen", doorOpen);
            }
            else
            {
                // Display a message or some feedback to indicate the condition is not met
                Debug.Log("Cannot open the door yet. Kill more enemies!");
            }
        }
    }
}