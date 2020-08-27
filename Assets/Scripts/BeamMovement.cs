using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamMovement : MonoBehaviour
{
    public GameObject Player;
    public GameObject thePlatform;
   private bool goingRight = true;
    public float moveSpeed = 1f;
  private bool onBeam = false;



  void Update()
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
       
    }
    private void OnCollisionEnter(Collision collision)

    {
        if (collision.gameObject.name == "CARMEL")
        {
            print("on");
            Player.transform.parent = thePlatform.transform;
        }
        
       
    }

    private void OnCollisionExit(Collision collision)

    {
        if (collision.gameObject.name == "CARMEL")
        {
            print("off");
            Player.transform.parent = null;
        }
    }


    //beam change direction obstical


    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.name == "BLOCKER")
        {
            goingRight = !goingRight;
        }
    }

}