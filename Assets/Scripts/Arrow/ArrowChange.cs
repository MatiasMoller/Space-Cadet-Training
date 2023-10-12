using UnityEngine;

public class ArrowChange : MonoBehaviour
{
    public ArrowIndicator arrowIndicator;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gate2"))
        {
            arrowIndicator.playerEnteredTrigger2 = true;
            arrowIndicator.playerEnteredTrigger3 = false;
            Debug.Log("Player entered Gate 2 trigger");
            // Additional actions related to the player can be added here
        }

        if (other.CompareTag("Gate3"))
        {
            arrowIndicator.playerEnteredTrigger2 = false;
            arrowIndicator.playerEnteredTrigger3 = true;
            Debug.Log("Player entered Gate 3 trigger");
        }
    }
}
