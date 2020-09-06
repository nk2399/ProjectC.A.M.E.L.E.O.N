using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderParenting : MonoBehaviour
{
    public GameObject PlayerGO;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerGO.transform.parent = transform.parent;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerGO.transform.parent = null;
        }
    }
}
