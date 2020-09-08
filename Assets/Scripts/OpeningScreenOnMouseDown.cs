using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningScreenOnMouseDown : MonoBehaviour
{

    private Vector3 mOffset;
    public AudioSource audiomeneger;
    public AudioClip play;


    private float mZCoord;



    void OnMouseDown()

    {

        mZCoord = Camera.main.WorldToScreenPoint(

            gameObject.transform.position).z;



        // Store offset = gameobject world pos - mouse world pos

        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

    }



    private Vector3 GetMouseAsWorldPoint()

    {

        // Pixel coordinates of mouse (x,y)

        Vector3 mousePoint = Input.mousePosition;



        // z coordinate of game object on screen

        mousePoint.z = mZCoord;



        // Convert it to world points

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }



    void OnMouseDrag()

    {

        transform.position = GetMouseAsWorldPoint() + mOffset;

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "STARTPLAY")
        {
          
           
            SceneManager.LoadScene("level 1 Take 3");
            audiomeneger.PlayOneShot(play);
        }
    }
    
}
 