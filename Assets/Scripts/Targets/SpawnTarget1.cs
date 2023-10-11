using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTarget1 : MonoBehaviour
{
    public Trainer trainerSC;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player crossed");
            trainerSC.SpawnTarget();
            this.gameObject.SetActive(false);
        }
    }
}
