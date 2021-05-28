using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Courtesy of Youtube Video "THIRD PERSON MOVEMENT in Unity" by Brackeys @ May 24, 2020
// and "FIRST PERSON MOVEMENT in Unity - FPS Controller by Brackeys @ Oct 27, 2019
// "HOLD JUMP KEY TO JUMP HIGHER - 2D PLATFORMER CONTROLLER - UNITY TUTORIAL by Blackthornprod @ Jul 9, 2018

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    private int Respawn;
    public bool gameOver = false;
    private float tooFar = 50.0f;

    [Header("Player Movement Values")]
    public float speed = 12f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public Vector3 moveDir;

    private Animator animPlayer;

    // Start is called before the first frame update
    void Start()
    {
        animPlayer = GameObject.Find("Distorter").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameOver)
        {
            // Get horizontal/vertical movement for movement direction
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            Vector3 dir = new Vector3(h, 0f, v).normalized;

            if (dir.magnitude >= 0.1f)
            {
                // Rotation
                float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                // Move
                moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir.normalized * speed * Time.deltaTime);

                animPlayer.SetFloat("Speed_f", 0.6f);
            }
            else animPlayer.SetFloat("Speed_f", 0.0f);
        }
        

        // Out of Bounds - Die
        if(transform.position.y < -tooFar)
        {
            GameOver();
        }
    }

    // Touch a "Kill" block [Red] w/ Invuln - Die
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Kill") && gameObject.CompareTag("Player"))
        {
            GameOver();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Kill") && gameObject.CompareTag("Player"))
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        gameOver = true;
        // Destroy(gameObject);

        //SceneManager.LoadScene(Respawn); [Commenting Out to test gameOver's pause requirement for Phase 3]
    }
}
