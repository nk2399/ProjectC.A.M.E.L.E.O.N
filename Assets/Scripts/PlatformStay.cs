using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformStay : MonoBehaviour
{
    public GameObject Player;
    public GameObject thePlatform;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("onplatform");

            Player.transform.parent = thePlatform.transform;
            // Player.transform.SetParent(gameObject.transform);
            print("ou");
            // }

        }
    }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject == Player)
            {

                Player.transform.parent = null;

            }
        }
    } 


