using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    private int Respawn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            SceneManager.LoadScene(Respawn);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Destroy(other.gameObject);
        SceneManager.LoadScene(Respawn);
    }
}
