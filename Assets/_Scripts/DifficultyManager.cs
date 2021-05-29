using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public GameObject moreSpawns;
    public int level = 0;

    public static int addSpawns = 0;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(moreSpawns, transform.position, transform.rotation);


        if (level < ThirdPersonMovement.wonLevels)
        {
            level = ThirdPersonMovement.wonLevels;
            Debug.Log("Level: " + level);

            if (SpawnManager.spawnRate > 1.0f)
            {
                SpawnManager.spawnRate -= 0.5f;
                Debug.Log("Spawn Rate: " + SpawnManager.spawnRate);
            }
        }

        if (level > 0 && level % 2 == 0)
        {
            addSpawns++;
        }

        for (int i = addSpawns; i > 0; i--)
            Instantiate(moreSpawns, transform.position, transform.rotation);
        Debug.Log("Additional Managers: " + addSpawns);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
