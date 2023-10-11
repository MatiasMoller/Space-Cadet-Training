using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowChange : MonoBehaviour
{
    public ArrowIndicator arrowIndicator;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            arrowIndicator.playerEnteredTrigger = true;
            Debug.Log("Player entered trigger");
            // Additional actions related to the player can be added here
        }
    }
}
