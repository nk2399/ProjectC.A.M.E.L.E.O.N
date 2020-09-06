using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformParenting : MonoBehaviour
{
    public bool onPlatform = false;
    public GameObject PlayerGO;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerGO.transform.parent = transform.parent;
            onPlatform = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            onPlatform = false;
            PlayerGO.transform.parent = null;
        }
    }
}