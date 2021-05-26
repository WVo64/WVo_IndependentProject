using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPDash : MonoBehaviour
{
    ThirdPersonMovement moveScript;

    public float dashSpeed = 30.0f;
    public float dashTime = 0.25f;
    public float dashCooldown = 0.6f;

    private bool canDash = true;

    // Start is called before the first frame update
    void Start()
    {
        moveScript = GetComponent<ThirdPersonMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && canDash == true)
        {
            StartCoroutine(Dash());
        }

        Debug.Log("Player Again");
        gameObject.tag = "Player";
    }

    IEnumerator Dash()
    {
        // Courtesy of gamedev friend: D.V. [only initials due to privacy] for helping me fix this code to have the cooldown and invuln properly.
        float startTime = Time.time;

        canDash = false;
        while (Time.time - startTime < dashTime)
        {
            moveScript.controller.Move(moveScript.moveDir * dashSpeed * Time.deltaTime);

            gameObject.tag = "Invuln";
            Debug.Log("Invulnerable");

            yield return null;
        }

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
