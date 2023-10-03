using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 5f;
    public Trainer trainerSC;
    MathewHartley.GameManager gameManagerScript;

    private void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<MathewHartley.GameManager>();
    }

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
        gameManagerScript.TargetDestroyed();

        if (gameManagerScript.killCount < 10)
        {
            if (this.CompareTag("Target1"))
            {
                trainerSC.SpawnTarget();
            }
            else if (this.CompareTag("Target2"))
            {
                trainerSC.SpawnTarget2();
            }
        }
    }

}
