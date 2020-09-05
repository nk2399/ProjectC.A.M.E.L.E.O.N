﻿using System.Collections;
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
    public float z;
    public float x;

    //Jump
    Rigidbody rb;
    bool ground;

    //Animation
    public Animator Animator;
    bool rifle;

    //Gun
    public GameObject Gun;
    public Transform HandPostion;
    public GameObject ShootPoint;
    public GameObject Bullet;

    //Transperent
    Renderer rend;
    Renderer rendeyes;
    public GameObject body;
    public GameObject eyes;
    public Collider col;
    public LayerMask groundCheck;

    //Run
    bool running;

    // Start is called before the first frame update
    void Start()
    {
        ground = false;
        RotationSpeed = 250f;
        speed = 80;
        rb = GetComponent<Rigidbody>();
        rifle = false;
        rend = body.GetComponent<Renderer>();
        rendeyes = eyes.GetComponent<Renderer>();
        rend.enabled = true;
        rendeyes.enabled = true;
        running = false;
        Animator.SetBool("running", false);
        col.enabled = true;
       
    }

    // Update is called once per frame
    void Update()
    {
        // ground check
        
        Cursor.lockState = CursorLockMode.Locked;
        //Camera
        Rotation = Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime;
        transform.Rotate(0, Rotation, 0);

        CameraRotation = Input.GetAxis("Mouse Y") * RotationSpeed * Time.deltaTime;
        CameraFinal -= CameraRotation;
        CameraFinal = Mathf.Clamp(CameraFinal, -90, 65);
        Camera.localRotation = Quaternion.Euler(CameraFinal, 0, 0);


        //Movement
        x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        z = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(x, 0, z);

        //Jump
        if (Input.GetKey(KeyCode.Space) && ground)
        {
            
            rb.AddForce(0, 2500, 0);
        }

        if (ground == false)
        {
            rb.AddForce(0, -25, 0);
        }

        //Animation

        //Walking
        if (x>0 || z>0 && rifle == false)
        {
            Animator.SetBool("walking", true);
        }

        if (x==0 && z==0 && rifle == false)
        {
            Animator.SetBool("walking", false);
        }

        if (x > 0 || z > 0 && rifle)
        {
            Animator.SetBool("WalkingRifle", true);
            Animator.SetBool("rifle", false);
        }

        if (x == 0 && z == 0 && rifle)
        {
            Animator.SetBool("WalkingRifle", false);
            Animator.SetBool("rifle", true);
        }



            //Run
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 160;
                Animator.SetBool("running", true);
                Animator.SetBool("walking", false);
                Animator.SetBool("WalkingRifle", false);
              
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed = 80;
                Animator.SetBool("running", false);
            }




        //Shooting

        if (Input.GetMouseButtonDown(0) && rifle)
        {
            Instantiate(Bullet, ShootPoint.transform.position, ShootPoint.transform.rotation);

        }

        //Transperent
        if (Input.GetKeyDown(KeyCode.G) && x < 0.3f && z < 0.31f)
            {
                rend.enabled = false;
                rendeyes.enabled = false;
                col.enabled = false;
                rb.useGravity = false;
                speed = 0;
            }



            if (Input.GetKeyUp(KeyCode.G))
            {
                rend.enabled = true;
                rendeyes.enabled = true;
                col.enabled = true;
                rb.useGravity = true;
                speed = 80;

        }









    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            ground = true;
            Animator.SetBool("jumping", false);

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            ground = false;
            Animator.SetBool("jumping", true);
        }
    }


    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Rifle")
        {
            rifle = true;
            Gun.transform.parent = HandPostion.transform;
            Gun.transform.localPosition = new Vector3(0.0017f, 0.007f, 0.0153f);
            Gun.transform.localEulerAngles = new Vector3(-23.522f, 79.60201f, -429.104f);
        }
    }


}
