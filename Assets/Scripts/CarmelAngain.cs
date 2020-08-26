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

    //Animation
    public Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        RotationSpeed = 250f;
        speed = 80;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //Camera
        Rotation = Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime;
        transform.Rotate(0, Rotation, 0);

        CameraRotation = Input.GetAxis("Mouse Y") * RotationSpeed * Time.deltaTime;
        CameraFinal -= CameraRotation;
        CameraFinal = Mathf.Clamp(CameraFinal, -20, 10);
        Camera.localRotation = Quaternion.Euler(CameraFinal, 0, 0);


        //Movement
        x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        z = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(x, 0, z);

        //Jump
        if (Input.GetKey(KeyCode.Space) && ground)
        {
            rb.AddForce(0, 1000, 0);
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
