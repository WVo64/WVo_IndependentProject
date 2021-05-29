using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private ThirdPersonMovement TPM;
    private Transform groundSize;

    public GameObject[] platWallPrefabs;

    public float startTime = 1.0f;
    public static float spawnRate = 5.0f;
    public int difficultyLevel = 0;


    // Start is called before the first frame update
    void Start()
    {
        TPM = GameObject.Find("Player").GetComponent<ThirdPersonMovement>();
        groundSize = GameObject.Find("Ground").GetComponent<Transform>();

        InvokeRepeating("SpawnPlatWalls", startTime, spawnRate);
    }

    void SpawnPlatWalls()
    {
        if(TPM.gameOver == false)
        {
            int platWallPrefabsIndex = Random.Range(0, platWallPrefabs.Length);

            Instantiate(platWallPrefabs[platWallPrefabsIndex], randomPos(),
                 gameObject.transform.rotation);
        }
    }

    Vector3 randomPos()
    {
        float spawnHalf = groundSize.localScale.x / 2;
        float randSpawn = Random.Range(-groundSize.localScale.x + spawnHalf, groundSize.localScale.x - spawnHalf);
        return new Vector3(randSpawn, transform.position.y, transform.position.z);
    }
}
