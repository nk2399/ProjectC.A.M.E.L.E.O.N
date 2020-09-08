using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugHit : MonoBehaviour
{
    GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        player = GameObject.Find("CARMEL");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<CarmelAngain>().lifecounter--;

        }
    }
}
