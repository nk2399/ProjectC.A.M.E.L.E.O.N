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
    float z;
    float x;

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

    // Start is called before the first frame update
    void Start()
    {
        RotationSpeed = 250f;
        speed = 80;
        rb = GetComponent<Rigidbody>();
        rifle = false;
        rend = body.GetComponent<Renderer>();
        rendeyes = eyes.GetComponent<Renderer>();
        rend.enabled = true;
        rendeyes.enabled = true;
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

        //Shooting

        if (Input.GetMouseButtonDown(0) && rifle)
        {
            Instantiate(Bullet, ShootPoint.transform.position, ShootPoint.transform.rotation);
            rb.AddForce(400, 0, 0);
        }

        //Transperent
        if (Input.GetKeyDown(KeyCode.G))
        {
            rend.enabled = false;
            rendeyes.enabled = false;
        }

        if (Input.GetKeyUp(KeyCode.G))
        {
            rend.enabled = true;
            rendeyes.enabled = true;
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
