using System.Collections;
using UnityEngine;

public class Trainer : MonoBehaviour
{
    public GameObject targetPrefab;
    public GameObject targetPrefab2;
    public GameObject targetPrefab3;
    public static Trainer instance;
    


    public void SpawnTarget()
    {
        float randomX = Random.Range(-6f, 6f);
        float randomY = Random.Range(-4f, 1f);
        float randomZ = Random.Range(-67f, -77f);

        Vector3 randomSpawn = new Vector3(randomX, randomY, randomZ);
        Instantiate(targetPrefab, randomSpawn, Quaternion.identity);
    }

    public void SpawnTarget2()
    {
       float randomX = Random.Range(-23f, -28f);
        float randomY = Random.Range(11f, 6f);
        float randomZ = Random.Range(-23f, -13f);
        Vector3 randomSpawn2 = new Vector3(randomX, randomY, randomZ);
       Instantiate(targetPrefab2, randomSpawn2, Quaternion.identity);
    }
    public void SpawnTarget3()
    {
        float randomX = Random.Range(-20f, -7f);
        float randomY = Random.Range(2f, -2f);
        float randomZ = Random.Range(66f, 77f);
        Vector3 randomSpawn3 = new Vector3(randomX, randomY, randomZ);
        Instantiate(targetPrefab3, randomSpawn3, Quaternion.identity);
    }
}
