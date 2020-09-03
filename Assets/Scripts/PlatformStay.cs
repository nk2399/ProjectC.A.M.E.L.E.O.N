using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformStay : MonoBehaviour
{
    public GameObject Player;
    public GameObject thePlatform;
    public bool onBeam = false;
   

  

    private void OnTriggerEnter(Collider other)
    {
        // if (other.gameObject.tag == "Player")

        //if (other.gameObject.name == "CarmelPlayer")
        if (other.gameObject.name == "CARMEL")
        {
            print("onplatform");
            onBeam = true;
            Player.transform.parent = thePlatform.transform;
           
            
        }
    }
   private void OnTriggerExit(Collider other)
    {
        onBeam = false;
     
            print("off of platform");
        if (other.gameObject.name == "CARMEL")
            Player.transform.parent = null;
           // transform.parent = null;

        }
    }



