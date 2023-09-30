using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 5f;
    public Trainer trainerSC;

    public void TakeDamage(float amount)
    {
        health-= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        trainerSC.SpawnTarget();
        
    }
}
