using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 10;
    private float spawnPosZ = 25;

    public float sideSpawnMinZ;
    public float sideSpawnMaxZ;
    public float sideSpawnX;

    private float startDelay = 1;
    
    void Start()
    {
        Invoke("SpawnRandomAnimal", startDelay);
    }


    void SpawnRandomAnimal()
    {
        // declare random position, random animal index, random position index, random spawn interval
        Vector3 spawnPosUp = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Vector3 spawnPosLeft = new Vector3(-sideSpawnX, 0, Random.Range(sideSpawnMinZ, sideSpawnMaxZ));
        Vector3 spawnPosRight = new Vector3(sideSpawnX, 0, Random.Range(sideSpawnMinZ, sideSpawnMaxZ));
        Vector3[] spawnPos = new[] { spawnPosUp, spawnPosLeft, spawnPosRight };
        Vector3[] rotation = new[] { new Vector3(0, 180, 0), new Vector3(0, 90, 0), new Vector3(0, -90, 0) };

        int animalIndex = Random.Range(0, animalPrefabs.Length);
        int spawnIndex = Random.Range(0, spawnPos.Length);
        float spawnInterval = Random.Range(1f, 2.2f);

        Instantiate(animalPrefabs[animalIndex], spawnPos[spawnIndex], Quaternion.Euler(rotation[spawnIndex]));

        Invoke("SpawnRandomAnimal", spawnInterval);
    }
}
