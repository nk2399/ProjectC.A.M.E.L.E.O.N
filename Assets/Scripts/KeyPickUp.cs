using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    public Transform playerKeyHolder;
    public Transform jailDoorKeyHolder;
    private bool tookKeyOnce= false;
    public GameObject jailDoor;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && tookKeyOnce == false)  
        {
            tookKeyOnce = true;
            transform.parent = playerKeyHolder.transform;
            transform.position = playerKeyHolder.position;//new Vector3(playerTransform.x, playerTransform.position.y - 6f, playerTransform.position.z);
            
            print ("gotcha!");
        }
        if (collider.gameObject.tag == "JAILDOOR")
        {
           
            tookKeyOnce = true;
            transform.parent = jailDoorKeyHolder.transform;
            transform.position = jailDoorKeyHolder.position;
            transform.rotation = jailDoorKeyHolder.rotation;
            jailDoor.GetComponent<Transform>();
            ///jailDoor.  rotate on hinge 90
            //jailDoor.transform.Rotate(0,78,0);
            

        }
        
        

    }
}
