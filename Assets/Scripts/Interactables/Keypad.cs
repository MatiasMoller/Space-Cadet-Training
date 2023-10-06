using MathewHartley;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactable
{
    [SerializeField] private GameObject firstDoor;
    [SerializeField] private GameObject secondDoor;
    private bool firstDoorOpen;
    private bool secondDoorOpen;

    // Reference to the GameManager
    private GameManager gameManager;

    private void Start()
    {
        // Find the GameManager in the scene
        gameManager = FindObjectOfType<GameManager>();
    }

    protected override void Interact()
    {
        // Check if the first door is closed
        if (!firstDoorOpen)
        {
            // Open the first door
            firstDoorOpen = true;
            firstDoor.GetComponent<Animator>().SetBool("IsOpen", true);
        }
        else
        {
            // Check if the kill count is 9 or more for the second door
            if (gameManager.killCount >= 9 && !secondDoorOpen)
            {
                // Open the second door
                OpenSecondDoor();
            }
            else
            {
                // Display a message or perform some action indicating that the player
                // needs to kill more enemies to access the second door.
                Debug.Log("You need to kill more enemies to access the second door.");
            }
        }
    }

    private void OpenSecondDoor()
    {
        secondDoorOpen = true;
        secondDoor.GetComponent<Animator>().SetBool("IsOpen", true);
    }
}
