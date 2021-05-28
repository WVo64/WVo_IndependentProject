using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Courtesy of Youtube Video "THIRD PERSON MOVEMENT in Unity" by Brackeys @ May 24, 2020
// and "FIRST PERSON MOVEMENT in Unity - FPS Controller by Brackeys @ Oct 27, 2019
// "HOLD JUMP KEY TO JUMP HIGHER - 2D PLATFORMER CONTROLLER - UNITY TUTORIAL by Blackthornprod @ Jul 9, 2018

public class JumpGravity : MonoBehaviour
{
    private ThirdPersonMovement TPM;
    private Animator animPlayer;

    private float gravity = -18.36f;

    public CharacterController controller;
    public Transform groundCheck;


    public float jumpHeight = 3f;
    public float jumpTime = 0.6f;

    private float jumpTimeCounter;

    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        TPM = GameObject.Find("Distorter").GetComponent<ThirdPersonMovement>();
        animPlayer = GameObject.Find("Distorter").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TPM.gameOver == false)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            // Gravity
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);


            // Jump
            if (isGrounded && Input.GetKey(KeyCode.Space))
            {
                // Play Jump Animation ONCE
                if(isGrounded && Input.GetKeyDown(KeyCode.Space))
                {
                    animPlayer.SetTrigger("Jump_trig");
                }
                
                isJumping = true;
                jumpTimeCounter = jumpTime;
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            // Still holding Space while jumping = Higher Jump
            if (Input.GetKey(KeyCode.Space) && isJumping)
            {
                if (jumpTimeCounter > 0)
                {
                    velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                    jumpTimeCounter -= Time.deltaTime;
                }
                else
                {
                    isJumping = false;
                }
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                isJumping = false;
            }
        }
    }
}
