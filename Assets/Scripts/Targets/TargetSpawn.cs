using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TargetSpawn : MonoBehaviour
{
    public Trainer trainerSC;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player crossed");
            trainerSC.SpawnTarget2();
            this.gameObject.SetActive(false);
        }
    }
}
