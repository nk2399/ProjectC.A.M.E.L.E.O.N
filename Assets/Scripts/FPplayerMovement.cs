using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FPplayerMovement : MonoBehaviour
{

    private float x;
    private float z;
    private Vector3 move;
    public CharacterController controller;
    public float speed = 50f;    // change speed at run button up as well
    private Vector3 velocity;
    public float gravity = -250f;

    //ground Check

    public Transform groundCheck;
    public float groundDistance = 1f;       //radius of check
    public LayerMask groundMask;
    public bool isGrounded;

    // jump

    private float jumpHeight = 20f;
    private int jumpCounter = 2;

    // jump rotate

    public bool isflipping;

    //run

    private bool isRunning = false;

    //Crouching

    private bool isCrouching = false;

    // Beer
    
    //public AudioSource audiosource;
   // public AudioClip PowerUp;
   // public AudioClip jump;
   

    //mouse look

    private float mouseX;
    private float mouseY;
    public Transform playerBody;
    private float xRotation;
    public Transform camTransform;
    private float playerScale;
    [SerializeField]
    private int mouseSensetivity;

    private void Start()
    {
        playerScale = transform.localScale.y;
        xRotation = 0f;
        mouseSensetivity = 400;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); // setting a sphere on the object , at the radii on groundDistance, at collision with layermask,  and setting the bool accordingly.

        if (isGrounded && velocity.y < 0)   //ground and not moving upwards)
        {
            jumpCounter = 2;
            velocity.y = -2f;  // an extra distance until reaching the ground first time--  same as, velocity.y = 0f

            isGrounded = true;
        }

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);


        // mouse look
        mouseX = Input.GetAxis("Mouse X") * mouseSensetivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensetivity * Time.deltaTime;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        camTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);



        // jump

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            jumpCounter = 1;
            isGrounded = false;
            isflipping = false;
           // audiosource.PlayOneShot(jump);


        }
        else if (Input.GetButtonDown("Jump") && isGrounded == false && jumpCounter == 1)
        {
            isflipping = true;
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            jumpCounter -= 1;
            

        }
               

        //Run
        if (Input.GetKeyDown(KeyCode.LeftShift) && isRunning == false)
        {
            speed += speed;
            isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) && isRunning == true)
        {
            speed = 50f;                                                       // change speed here as well!!
            isRunning = false;

        }

        // crouching
        if (Input.GetKeyDown(KeyCode.C) && isCrouching == false)
        {


            transform.localScale = new Vector3(transform.localScale.x, playerScale/2, transform.localScale.z);

            isCrouching = true;

        }

        if (Input.GetKeyUp(KeyCode.C) && isCrouching == true)
        {

            transform.localScale = new Vector3(transform.localScale.x, 4.5f, transform.localScale.z);
            isCrouching = false;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
}
                  
   

