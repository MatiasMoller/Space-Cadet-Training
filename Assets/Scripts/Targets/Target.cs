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
        health-= amount;
        if ((health <= 0) && this.CompareTag("Target3"))
        {
            thisRender3A.enabled = false;
            thisRender3B.enabled = false;
            StartCoroutine(WaitToDie());
        }
        else if (health <= 0)
        {
            thisRender.enabled = false;
            StartCoroutine(WaitToDie());
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
