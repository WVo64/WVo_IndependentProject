using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    public GameObject[] platWallPrefabs;
    public float PosRange = 10;

    public float repeatTime = 1.0f;
    public float spawnRate = 1.0f;

    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPlatWalls", repeatTime, spawnRate);
    }

    void SpawnPlatWalls()
    {
        int platWallPrefabsIndex = Random.Range(0, platWallPrefabs.Length);

       Instantiate(platWallPrefabs[platWallPrefabsIndex], transform.position,
            platWallPrefabs[platWallPrefabsIndex].transform.rotation);
    }
}
