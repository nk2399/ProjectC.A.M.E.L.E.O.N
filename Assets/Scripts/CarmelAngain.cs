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
    public bool detected;

    //Run
    bool running;

    //Ladder
    public GameObject Ladder;
    private bool onLadder=false;

    //Life
    public int lifecounter;
    public GameObject Ghost;

    //ENEMIES
    public GameObject black01;
    public GameObject black02;
    public GameObject black03;
    public GameObject brown01;
    public GameObject brown02;
    int blackspider01;
    int blackspider02;
    int blackspider03;
    int brownpider01;
    int brownpider02;
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
        lifecounter = 50;
        blackspider01 = 1;
        blackspider02 = 1;
        blackspider03 = 1;
        brownpider01 = 1;
        brownpider02 = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // curser lock
        
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

        if (onLadder == false)
        {
            transform.Translate(x, 0, z);
        }
        else if (onLadder == true)
        {

            transform.Translate(0, z*3, 0);
           
        }
        //Jump
        if (Input.GetKey(KeyCode.Space) && ground)
        {
            
            rb.AddForce(0, 5000, 0);
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

            //LIFE

            if (lifecounter <= 0 && lifecounter >-50)
        {
            rend.enabled = false;
            Instantiate(Ghost, transform.position, transform.rotation);
            lifecounter = -60;
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

        if (other.gameObject.tag == "Ladder")
        {
            onLadder = true;
        }

        //INT ENEMIES

        if (detected && blackspider01 >=0)
        {
            Instantiate(black01, new Vector3(transform.localPosition.x-200, transform.localPosition.y,transform.localPosition.z-200), transform.localRotation);
            blackspider01 = blackspider01-2;
        }

        if (detected && blackspider02 >= 0)
        {
            Instantiate(black02, new Vector3(transform.localPosition.x - 300, transform.localPosition.y, transform.localPosition.z - 100), transform.localRotation);
            blackspider02 = blackspider02 - 2;
        }

        if (detected && blackspider03 >= 0)
        {
            Instantiate(black03, new Vector3(transform.localPosition.x - 100, transform.localPosition.y, transform.localPosition.z - 300), transform.localRotation);
            blackspider03 = blackspider03 - 2;
        }


        if (detected && brownpider01 >= 0)
        {
            Instantiate(brown01, new Vector3(transform.localPosition.x - 10, transform.localPosition.y, transform.localPosition.z - 250), transform.localRotation);
            brownpider01 = brownpider01 - 2;
        }

        if (detected && brownpider02 >= 0)
        {
            Instantiate(brown02, new Vector3(transform.localPosition.x - 200, transform.localPosition.y, transform.localPosition.z + 200), transform.localRotation);
            brownpider02 = brownpider02 - 2;
        }
    }

    
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Ladder")
        {
            onLadder = false;
        }
    }


}
