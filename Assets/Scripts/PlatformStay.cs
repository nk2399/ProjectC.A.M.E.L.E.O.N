using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformStay : MonoBehaviour
{
    public GameObject Player;
    public GameObject thePlatform;
    public bool onBeam = false;


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
}

   