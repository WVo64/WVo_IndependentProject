using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 10.0f;

    [Header("1Forward/Backward2, 3Up/Down4, 5Left/Right6")]
    public int directionNum;

    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        if(directionNum == 1)
        {
            direction = Vector3.forward;
        }
        else if (directionNum == 2)
        {
            direction = Vector3.back;
        }
        else if (directionNum == 3)
        {
            direction = Vector3.up;
        }
        else if (directionNum == 4)
        {
            direction = Vector3.down;
        }
        else if (directionNum == 5)
        {
            direction = Vector3.left;
        }
        else if (directionNum == 6)
        {
            direction = Vector3.right;
        }
        else
        {
            direction = Vector3.forward;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime * speed);
    }
}
