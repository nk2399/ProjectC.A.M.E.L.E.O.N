using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BUG : MonoBehaviour

{

    public GameObject Player;
    float MoveSpeed = 100f;
    int MaxDist = 10;
    int MinDist = 400;
    private Transform PlayerTransform;
    public Animator animator;
    int life;
    float timecounter;
   // public Animation anim;

    void Start()
    {
        //animalCounter = GameObject.Find("AnimalCounter");
        Player = GameObject.Find("CARMEL");
        PlayerTransform = Player.transform;
        life = 15;
        timecounter = 4;
    }

    void Update()
    {
        transform.LookAt(PlayerTransform);

        if (Vector3.Distance(transform.position, PlayerTransform.position) <= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            animator.SetBool("Walk Forward", true);
        }

       


        if (life <= 0)
        {
            timecounter = timecounter - Time.deltaTime;
            MoveSpeed = 0;
            animator.SetBool("die", true);
        }

        if (timecounter <= 0)
        {
            Destroy(gameObject);
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            MoveSpeed = 0;
            animator.SetBool("Attack", true);
            
        }


        if (other.gameObject.tag == "bullet")
        {
            life--;
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.SetBool("Walk Forward", true);
            animator.SetBool("Attack", false);
            MoveSpeed = 100;
        }
    }


}

