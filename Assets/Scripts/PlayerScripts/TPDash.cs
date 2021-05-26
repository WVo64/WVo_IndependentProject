using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPDash : MonoBehaviour
{
    ThirdPersonMovement moveScript;

    public float dashSpeed;
    public float dashTime;
    public float dashCooldown;

    // Start is called before the first frame update
    void Start()
    {
        moveScript = GetComponent<ThirdPersonMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            StartCoroutine(Dash());

            gameObject.tag = "Player";
            Debug.Log("Player");
        }
    }

    IEnumerator Dash()
    {
        float startTime = Time.time;

        gameObject.tag = "Invuln";
        Debug.Log("Invulnerable");

        while (Time.time < startTime + dashTime)
        {
            moveScript.controller.Move(moveScript.moveDir * dashSpeed * Time.deltaTime);

            

            yield return null;
        }
    }
}
