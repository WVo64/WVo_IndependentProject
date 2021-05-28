using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGravity : MonoBehaviour
{
    private ThirdPersonMovement TPM;
    private Animator dummyPlayer;

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
        TPM = GameObject.Find("Player").GetComponent<ThirdPersonMovement>();
        dummyPlayer = GameObject.Find("MaleDummy").GetComponent<Animator>();
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
                isJumping = true;
                jumpTimeCounter = jumpTime;
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

                dummyPlayer.SetTrigger("Jump_trig");
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
