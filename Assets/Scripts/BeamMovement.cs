using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamMovement : MonoBehaviour
{
    public GameObject player;
    private bool goingRight = true;
    public float moveSpeed = 1f;
    private bool onBeam = false;



  /* void Update()
    {
        if (goingRight == true)
        {
            Vector3 myPosition = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            transform.position = myPosition;

        }
        if (goingRight == false)
        {
            Vector2 myPosition = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            transform.position = myPosition;

        }

    }*/
    private void OnTriggerEnter(Collider other)
    {
       /* if (other.gameObject.tag == "ChangeDirClaw")
        {
            goingRight = !goingRight;

        }*/
        if (other.gameObject.name == "Carmel")
        {
            print("onplatform");
            onBeam = true;
           // player.transform.parent = transform;
            player.transform.SetParent(gameObject.transform);

        }

    }
  
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject== player)
        {
            onBeam = false;
            player.transform.parent = null;

        }
    }
}
    