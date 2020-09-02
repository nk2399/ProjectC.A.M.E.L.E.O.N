using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    public Transform playerKeyHolder;
    public Transform jailDoorKeyHolder;
    private bool tookKeyOnce= false;
    public GameObject jailDoor;
    public GameObject DoorLockCube;
    public GameObject newNoColliderKey;
   

 
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && tookKeyOnce == false)  
        {
           
            tookKeyOnce = true;
            newNoColliderKey = Instantiate (newNoColliderKey, playerKeyHolder.position, playerKeyHolder.transform.rotation ) ;
            newNoColliderKey.transform.parent = playerKeyHolder.transform;
            newNoColliderKey.transform.position = playerKeyHolder.position;
            Destroy(gameObject);
           



        }
       /* if (collider.gameObject.tag == "JAILDOOR")
        {
           
            tookKeyOnce = true;
            transform.parent = jailDoorKeyHolder.transform;
            transform.position = jailDoorKeyHolder.position;
            transform.rotation = jailDoorKeyHolder.rotation;
            Destroy(DoorLockCube);*/
          

        }
        
        

    }

