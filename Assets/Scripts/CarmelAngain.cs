using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarmelAngain : MonoBehaviour
{
    //Camera
    float CameraRotation;
    float Rotation;
    float RotationSpeed;
    float CameraFinal;
    public Transform Camera;

    //Movement
    float speed;
    float z;
    float x;

    //Jump
    Rigidbody rb;
    bool ground;
    private int doubleJumpCount;

    //Animation
    public Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        RotationSpeed = 250f;
        speed = 80;     //if changing here change line 64 as well . make run speed back to normal after buttonUp
        rb = GetComponent<Rigidbody>();
        doubleJumpCount = 2;
    }

    // Update is called once per frame
    void Update()
    {

        //Camera 

        CameraRotation = Input.GetAxis("Mouse Y") * RotationSpeed * Time.deltaTime;
        CameraFinal -= CameraRotation;
        CameraFinal = Mathf.Clamp(CameraFinal, -80, 80);    ////-20, 10);
        Camera.localRotation = Quaternion.Euler(CameraFinal, 0, 0);


        //Movement
        x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        z = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(x, 0, z);

        //Run

        if (Input.GetButtonDown("Fire3"))
        {
            speed = speed * 3;
        }
        else if (Input.GetButtonUp("Fire3")) 
        {
            speed = 80f;
        }
                
              
        
        //Jump

        if (Input.GetKey(KeyCode.Space) && ground && doubleJumpCount ==2)
        {
            rb.AddForce(0, 1000, 0);
            doubleJumpCount -= 1;
        }

        //double jump
        if (Input.GetKey(KeyCode.Space)  && doubleJumpCount == 1)
        {
            rb.AddForce(0, 1000, 0);
            doubleJumpCount -= 1;
        }


        //Animation
        if (x>0 || z>0)
        {
            Animator.SetBool("walking", true);
        }

        if (x==0 && z==0)
        {
            Animator.SetBool("walking", false);
        }

    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            ground = true;
            doubleJumpCount = 2;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            ground = false;
        }
    }

 


}
