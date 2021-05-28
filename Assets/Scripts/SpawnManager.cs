using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private ThirdPersonMovement TPM;

    public GameObject[] platWallPrefabs;
    public float PosRange = 10;

    public float repeatTime = 1.0f;
    public float spawnRate = 1.0f;

    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        TPM = GameObject.Find("Distorter").GetComponent<ThirdPersonMovement>();

        InvokeRepeating("SpawnPlatWalls", repeatTime, spawnRate);
    }

    void SpawnPlatWalls()
    {
        if(TPM.gameOver == false)
        {
            int platWallPrefabsIndex = Random.Range(0, platWallPrefabs.Length);

            Instantiate(platWallPrefabs[platWallPrefabsIndex], transform.position,
                 platWallPrefabs[platWallPrefabsIndex].transform.rotation);
        }
    }
}
