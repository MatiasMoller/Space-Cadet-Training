using System.Collections;
using UnityEngine;

public class Trainer : MonoBehaviour
{
    public GameObject targetPrefab;
    public GameObject targetPrefab2;
    public GameObject targetPrefab3;
    public GameObject particleEffectPrefab;
    public static Trainer instance;

    public void Start()
    {
        instance = this; // Assign the instance in Start() method
    }

    public void SpawnParticleEffect(Vector3 spawnPosition)
    {
        GameObject particleEffect = Instantiate(particleEffectPrefab, spawnPosition, Quaternion.identity);
        Destroy(particleEffect, 1f); // Destroy the particle effect after 1 second
    }

    public void SpawnTarget()
    {
        float randomX = Random.Range(-6f, 6f);
        float randomY = Random.Range(-4f, 1f);
        float randomZ = Random.Range(-67f, -77f);

        Vector3 randomSpawn = new Vector3(randomX, randomY, randomZ);

        SpawnParticleEffect(randomSpawn); // Call the method to spawn the particle effect at the target position

        // Adjust the y-axis value slightly
        randomSpawn.y += -1f;

        Instantiate(targetPrefab, randomSpawn, Quaternion.identity);
    }

    // Repeat the same pattern for SpawnTarget2 and SpawnTarget3

    // Repeat the same pattern for SpawnTarget2 and SpawnTarget3


    public void SpawnTarget2()
    {
        float randomX = Random.Range(-48f, -28f);
        float randomY = Random.Range(10f, 6f);
        float randomZ = Random.Range(-23f, -13f);
        Vector3 randomSpawn2 = new Vector3(randomX, randomY, randomZ);

        SpawnParticleEffect(randomSpawn2); // Call the method to spawn the particle effect at the target position

        Instantiate(targetPrefab2, randomSpawn2, Quaternion.identity);
    }

    public void SpawnTarget3()
    {
        float randomX = Random.Range(-43f, -23f);
        float randomY = Random.Range(10f, 15f);
        float randomZ = Random.Range(-43f, -23f);
        Vector3 randomSpawn3 = new Vector3(randomX, randomY, randomZ);

        SpawnParticleEffect(randomSpawn3); // Call the method to spawn the particle effect at the target position

        // Use Quaternion.Euler to create a rotation quaternion for 180 degrees around the Y-axis
        Quaternion rotation = Quaternion.Euler(0f, 180f, 0f);

        Instantiate(targetPrefab3, randomSpawn3, rotation);
    }
}
