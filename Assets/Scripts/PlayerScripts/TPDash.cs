using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPDash : MonoBehaviour
{
    ThirdPersonMovement moveScript;
    private Animator animPlayer;

    public float dashSpeed = 30.0f;
    public float dashTime = 0.25f;
    public float dashCooldown = 0.6f;

    private bool canDash = true;

    // Start is called before the first frame update
    void Start()
    {
        moveScript = GetComponent<ThirdPersonMovement>();
        animPlayer = GameObject.Find("Distorter").GetComponent<Animator>();
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

            // "Dash Animation" - Ends as soon as dash move is done
            animPlayer.SetBool("Dash", true);

            gameObject.tag = "Invuln";
            Debug.Log("Invulnerable");

            yield return null;
        }
        animPlayer.SetBool("Dash", false);

        yield return new WaitForSeconds(dashCooldown);        
        canDash = true;
    }
}
