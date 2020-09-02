using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewKey : MonoBehaviour
{
    private GameObject jailDoorKeyHolder;
    private GameObject DoorLockCube;

    private void OnTriggerEnter(Collider collider)
    {
        GameObject jailDoorKeyHolder = GameObject.FindWithTag("JAILDOORKEYPLACE");
        GameObject DoorLockCube = GameObject.FindWithTag("DoorLockCube");

        if (collider.gameObject.tag == "JAILDOOR")
        {

            transform.parent = jailDoorKeyHolder.transform;
            transform.position = jailDoorKeyHolder.transform.position;
            transform.rotation = jailDoorKeyHolder.transform.rotation;
            Destroy(DoorLockCube);
           
        }
    }
}
    