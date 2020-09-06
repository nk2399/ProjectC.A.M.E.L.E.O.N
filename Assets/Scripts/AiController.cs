using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AiController : MonoBehaviour

{

    public GameObject Player;
    float MoveSpeed = 60f;
    int MaxDist = 10;
    int MinDist = 300;
    private Transform PlayerTransform;
    public Animation anim;
    int life;
    public GameObject browndead;
    public GameObject blackdead;
    float timecounter;


    void Start()
    {
        //animalCounter = GameObject.Find("AnimalCounter");
        Player = GameObject.Find("CARMEL");
        PlayerTransform = Player.transform;
        life = 10;
        timecounter = 4;
        
    }

    void Update()
    {
        transform.LookAt(PlayerTransform);

       if (Vector3.Distance(transform.position, PlayerTransform.position) <= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            anim.Play("walk");
        }

       if (life <=0)
        {
            timecounter = timecounter - Time.deltaTime;
            anim.RemoveClip("hit2");
            anim.RemoveClip("walk");
            anim.Play("death1");
            MoveSpeed = 0;
        }

       if (timecounter <=0)
        {
            Destroy(gameObject);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.RemoveClip("walk");
            anim.Play("hit2");
            MoveSpeed = 0;
        }


        if(other.gameObject.tag == "bullet")
        {
            life--;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            anim.Play("walk");
            MoveSpeed = 100;
        }
    }


}

