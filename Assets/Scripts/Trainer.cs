using System.Collections;
using UnityEngine;

public class Trainer : MonoBehaviour
{
    public GameObject targetPrefab;
    public static Trainer instance;
    


    public void SpawnTarget()
    {
        float randomX = Random.Range(-7f, 7f);
        float randomY = Random.Range(1f, 3f);
        float randomZ = Random.Range(-85f, -63f);

        Vector3 randomSpawn = new Vector3(randomX, randomY, randomZ);
        Instantiate(targetPrefab, randomSpawn, Quaternion.identity);
    }
}
