using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;

    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacle(Random.Range(0,obstaclePrefabs.Length), Random.Range(0,obstaclePrefabs.Length), Random.Range(0,obstaclePrefabs.Length));
        int sayi = Random.Range(0, 100);
        if (sayi % 2 == 0 && sayi > 50)
        {
            SpawnCloud(Random.Range(0,cloudPrefabs.Length));
        }
    }

    private void OnTriggerExit (Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }
    void Update()
    {
        
    }

    public GameObject[] obstaclePrefabs;
    public GameObject[] cloudPrefabs;


    void SpawnObstacle (int obstacleIndex, int obstacleIndex1, int obstacleIndex2)
    {
        Transform spawnPoint = transform.GetChild(Random.Range(2,4)).transform;
        Transform spawnPoint1 = transform.GetChild(Random.Range(4,6)).transform;
        Transform spawnPoint2 = transform.GetChild(Random.Range(6,8)).transform;

        Instantiate(obstaclePrefabs[obstacleIndex], spawnPoint.position, Quaternion.identity, transform);
        Instantiate(obstaclePrefabs[obstacleIndex1], spawnPoint1.position, Quaternion.identity, transform);
        Instantiate(obstaclePrefabs[obstacleIndex2], spawnPoint2.position, Quaternion.identity, transform);
    }

    void SpawnCloud (int cloudIndex)
    {
        int cloudSpawnIndex = Random.Range(8, 17);

        Transform cloudPoint = transform.GetChild(cloudSpawnIndex).transform;

        Instantiate(cloudPrefabs[cloudIndex], cloudPoint.position, Quaternion.identity, transform);
    }
}
