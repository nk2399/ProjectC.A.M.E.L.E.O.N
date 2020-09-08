using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarmelAngain : MonoBehaviour
{
    //Camera
    float CameraRotation;
    float Rotation;
    float RotationSpeed;
    float CameraFinal;
    public Camera cam;
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
    public GameObject eyes2;
    SkinnedMeshRenderer eyesrender;
    private bool gameOver = false;
    float restart;

    //ENEMIES
    public GameObject black01;
    public GameObject black02;
    public GameObject black03;
    public GameObject brown01;
    public GameObject brown02;
    public int blackspider01;
    public int blackspider02;
    public int blackspider03;
    public int brownpider01;
    public int brownpider02;

    //SOUNDS
    public AudioSource AudioMeneger;
    public AudioClip Shooting;
    public AudioClip wepon;
    public AudioClip jumping;
    public AudioClip hurt;
    public AudioClip graple;
    public AudioClip dead;
    public AudioClip transperenting;






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
        lifecounter = 55;
        blackspider01 = 1;
        blackspider02 = 1;
        blackspider03 = 1;
        brownpider01 = 1;
        brownpider02 = 1;
        eyesrender = eyes2.GetComponent<SkinnedMeshRenderer>();
        cam = GetComponent<SwitchCameras>().FPcamera;
        restart = 5;
        
    }

    // Update is called once per frame
    void Update()
    {
        // curser lock
       // if (gameOver == false)
            Cursor.lockState = CursorLockMode.Locked;
      /* if ( gameOver == true)
           Cursor.lockState = CursorLockMode.None;*/
        
        //Camera
        Rotation = Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime;
        transform.Rotate(0, Rotation, 0);

        CameraRotation = Input.GetAxis("Mouse Y") * RotationSpeed * Time.deltaTime;
        CameraFinal -= CameraRotation;
        CameraFinal = Mathf.Clamp(CameraFinal, -90, 65);
        cam.transform.localRotation = Quaternion.Euler(CameraFinal, 0, 0);


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
            
            rb.AddForce(0, 6500, 0);
            AudioMeneger.PlayOneShot(jumping);
        }

        if (ground == false)
        {
            rb.AddForce(0, -2, 0);
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

        if(x < 0 || z < 0 && rifle)
        {
            Animator.SetBool("WalkingRifle", false);
            Animator.SetBool("rifle", false);
            Animator.SetBool("walkingbackwards", true);
        }


        // GRAPLE
        if (Input.GetMouseButton(1))
        {
            Animator.SetBool("graple", true);
            
        }

        if (Input.GetMouseButtonUp(1))
        {
            Animator.SetBool("graple", false);
            AudioMeneger.PlayOneShot(graple);
        }




        //Run
        if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 160;

            running = true;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed = 80;
                running = false;
            }

            if(running)
        {
            Animator.SetBool("running", true);

        }
            if(running == false)
        {
            Animator.SetBool("running", false);
        }




        //Shooting

        if (Input.GetMouseButtonDown(0) && rifle)
        {
            Instantiate(Bullet, ShootPoint.transform.position, ShootPoint.transform.rotation);
            
        }

        if (Input.GetMouseButtonUp(0) && rifle)
        {
            AudioMeneger.PlayOneShot(Shooting);
        }


            //Transperent
            if (Input.GetKeyDown(KeyCode.G) && x < 0.3f && z < 0.31f)
            {
                rend.enabled = false;
                rendeyes.enabled = false;
                col.enabled = false;
                rb.useGravity = false;
                speed = 0;
                AudioMeneger.PlayOneShot(transperenting);
        }



            if (Input.GetKeyUp(KeyCode.G))
            {
                rend.enabled = true;
                rendeyes.enabled = true;
                col.enabled = true;
                rb.useGravity = true;
                speed = 80;
                AudioMeneger.PlayOneShot(transperenting);

        }

            //LIFE

            if (lifecounter <= 0 && lifecounter >-50)
        {
            gameOver = true;
            rend.enabled = false;
            Instantiate(Ghost, transform.position, transform.rotation);
            lifecounter = -60;
            Gun.GetComponent<Rifle>().dead = true;
            eyesrender.enabled = false;
            AudioMeneger.PlayOneShot(dead);

        }


            if(gameOver)
        {
            restart = restart - Time.deltaTime;
        }

            if (restart <=0)
        {
            SceneManager.LoadScene("restart");
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
            AudioMeneger.PlayOneShot(wepon);
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
            Instantiate(black02, new Vector3(transform.localPosition.x - 200, transform.localPosition.y, transform.localPosition.z - 100), transform.localRotation);
            blackspider02 = blackspider02 - 2;
        }

        if (detected && blackspider03 >= 0)
        {
            Instantiate(black03, new Vector3(transform.localPosition.x - 100, transform.localPosition.y, transform.localPosition.z - 200), transform.localRotation);
            blackspider03 = blackspider03 - 2;
        }


        if (detected && brownpider01 >= 0)
        {
            Instantiate(brown01, new Vector3(transform.localPosition.x - 10, transform.localPosition.y, transform.localPosition.z - 200), transform.localRotation);
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
