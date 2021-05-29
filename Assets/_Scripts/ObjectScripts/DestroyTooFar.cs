using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTooFar : MonoBehaviour
{
    public float tooFar = 600.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > tooFar || transform.position.y > tooFar || transform.position.z > tooFar
            || transform.position.x < -tooFar || transform.position.y < -tooFar || transform.position.z < -tooFar)
        {
            Destroy(gameObject);
        }
    }
}
