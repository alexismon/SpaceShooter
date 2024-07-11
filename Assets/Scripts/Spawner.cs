using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnPrefab;

    public float spawnWidth = 5;
    public float spawnTime = 1;
    private float currentSpawnTime = 0;

    void Update()
    {
        currentSpawnTime += Time.deltaTime;
        if (currentSpawnTime > spawnTime)
        {
            Vector3 position = transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0, 0);

            if (spawnPrefab.CompareTag("Ammo") || spawnPrefab.CompareTag("EnemyShip"))
            {
                Instantiate(spawnPrefab, position, spawnPrefab.transform.rotation);
            }
            else
            {
                Instantiate(spawnPrefab, position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            }

            currentSpawnTime = 0;
        }
    }
}
