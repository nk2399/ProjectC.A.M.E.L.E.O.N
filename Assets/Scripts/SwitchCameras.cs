using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCameras : MonoBehaviour
{
    public Camera FPcamera;
    public Camera TPcamera;
    public GameObject carmel;
    private bool switchCam = false;
    // Start is called before the first frame update
    void Start()
    {
        FPcamera.GetComponent<Camera>().enabled = true;
        TPcamera.GetComponent<Camera>().enabled = false;
        carmel.GetComponent<CarmelAngain>();
    }

    // Update is called once per frame
   void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.T))
        {
            switchCam = !switchCam;
       /*/
       if (switchCam == true)
        {
            FPcamera.GetComponent<Camera>().enabled = false;
            FPcamera.GetComponent<AudioListener>().enabled = false;
            TPcamera.GetComponent<Camera>().enabled = true;
            TPcamera.GetComponent<AudioListener>().enabled = true;
            
        } 
       else if (switchCam == false)
        {
            FPcamera.GetComponent<Camera>().enabled = true;
            FPcamera.GetComponent<AudioListener>().enabled = true;
            TPcamera.GetComponent<Camera>().enabled = false;
            TPcamera.GetComponent<AudioListener>().enabled = false;
        }
    }
    private void OnTriggerExit(Collider other)
    
    {
        if(other.gameObject.tag == "SwitchCam")
        {
            switchCam = true;
            GetComponent<CarmelAngain>().cam = TPcamera;
        }
    }

}
