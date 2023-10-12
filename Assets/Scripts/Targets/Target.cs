using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 5f;
    public Trainer trainerSC;
    MathewHartley.GameManager gameManagerScript;
    public Death deathSounds;
    private MeshRenderer thisRender;
    private Transform childCheck;
    private MeshRenderer thisRender3A;
    private MeshRenderer thisRender3B;

    public GameObject deathParticlePrefab;

    private void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<MathewHartley.GameManager>();
        if (this.CompareTag("Target3"))
        {
            childCheck = transform.Find("Body_Back");
            thisRender3A = childCheck.GetComponent<MeshRenderer>();
            childCheck = transform.Find("Body_Front");
            thisRender3B = childCheck.GetComponent<MeshRenderer>();
        }
        else
        {
            thisRender = this.gameObject.GetComponent<MeshRenderer>();
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        Vector3 spawnPosition = transform.position + new Vector3(0, 1.0f, 0); // Adjust the Y value as needed

        if ((health <= 0) && this.CompareTag("Target3"))
        {
            thisRender3A.enabled = false;
            thisRender3B.enabled = false;
            StartCoroutine(WaitToDie());
            GameObject deathParticle = Instantiate(deathParticlePrefab);
            deathParticle.transform.position = spawnPosition; // Use the adjusted position
            Destroy(deathParticle, 0.2f);
        }
        else if ((health <= 0) && (this.CompareTag("Target2") || this.CompareTag("Target1")))
        {
            thisRender.enabled = false;
            StartCoroutine(WaitToDie());
            GameObject deathParticle = Instantiate(deathParticlePrefab);
            deathParticle.transform.position = spawnPosition; // Use the adjusted position
            Destroy(deathParticle, 0.2f);
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

    IEnumerator WaitToDie()
    {
        deathSounds.PlayDeathSound1();
        yield return new WaitForSeconds(.5f);
        Die();
    }
}
