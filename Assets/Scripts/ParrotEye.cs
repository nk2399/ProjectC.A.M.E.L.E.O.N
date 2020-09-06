using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParrotEye : MonoBehaviour
{
    public GameObject parrot;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            parrot.GetComponent<Parrot>().detected = true;
            player.GetComponent<CarmelAngain>().detected = true;
        }

    }
}
