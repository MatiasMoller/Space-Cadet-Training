using UnityEngine;

public class ArrowChange : MonoBehaviour
{
    public ArrowIndicator arrowIndicator;

    public void OnTriggerEnter(Collider other)
    { 
        if (other.CompareTag("Gate1"))
        {
            arrowIndicator.activeTrigger = 1;
            Debug.Log("Player entered Gate 1 trigger");
        }
        else if (other.CompareTag("Gate2"))
        {
            arrowIndicator.activeTrigger = 2;
            Debug.Log("Player entered Gate 2 trigger");
        }
        else if (other.CompareTag("Gate3"))
        {
            arrowIndicator.activeTrigger = 3;
            Debug.Log("Player entered Gate 3 trigger");
        }
        else if (other.CompareTag("Gate4"))
        {
            arrowIndicator.activeTrigger = 4;
            Debug.Log("Player entered Gate 4 trigger");
        }
        else if (other.CompareTag("Gate5"))
        {
            arrowIndicator.activeTrigger = 5;
            Debug.Log("Player entered Gate 5 trigger");
        }
        else if (other.CompareTag("Gate6"))
        {
            arrowIndicator.activeTrigger = 6;
            Debug.Log("Player entered Gate 6 trigger");
        }
        else if (other.CompareTag("Gate7"))
        {
            arrowIndicator.activeTrigger = 7;
            Debug.Log("Player entered Gate 7 trigger");
        }
        else if (other.CompareTag("Gate8"))
        {
            arrowIndicator.activeTrigger = 8;
            Debug.Log("Player entered Gate 8 trigger");
        }
        else if (other.CompareTag("Gate9"))
        {
            arrowIndicator.activeTrigger = 9;
            Debug.Log("Player entered Gate 9 trigger");
        }
    }
}
