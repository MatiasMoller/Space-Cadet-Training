using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 5f;
    public Trainer trainerSC;
    MathewHartley.GameManager gameManagerScript;
    public Death deathSounds;
    
  

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
        deathSounds.PlayDeathSound1();

        if (gameManagerScript.killCount < 10)
        {
            
            if (this.CompareTag("Target1")) 
            {
               
                trainerSC.SpawnTarget();
            }
        }
        else if ((gameManagerScript.killCount < 20) && (this.CompareTag("Target2")))
        {
            trainerSC.SpawnTarget2();

        }
        else if ((gameManagerScript.killCount < 25) && (this.CompareTag("Target3")))
        {
            trainerSC.SpawnTarget3();
        }
    }
}
