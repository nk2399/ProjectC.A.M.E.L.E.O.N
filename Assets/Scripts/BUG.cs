using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BUG : MonoBehaviour

{

    public GameObject Player;
    float MoveSpeed = 100f;
    int MaxDist = 10;
    int MinDist = 300;
    private Transform PlayerTransform;
    public Animator animator;



    void Start()
    {
        //animalCounter = GameObject.Find("AnimalCounter");
        Player = GameObject.Find("Player");
        PlayerTransform = Player.transform;

    }

    void Update()
    {
        transform.LookAt(PlayerTransform);

        if (Vector3.Distance(transform.position, PlayerTransform.position) <= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            animator.SetBool("Walk Forward", true);
        }




    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            MoveSpeed = 0;
            animator.SetBool("Attack", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //animator.SetBool("Walk Forward", true);
            animator.SetBool("Attack", false);
            MoveSpeed = 100;
        }
    }


}

