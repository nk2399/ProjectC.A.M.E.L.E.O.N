using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parrot : MonoBehaviour
{

    public Animator Animator;
    public bool detected;
    public GameObject spotlight;
    public GameObject mesh;
    public MeshRenderer meshrend;
    float counter;


    // Start is called before the first frame update
    void Start()
    {
        meshrend = mesh.GetComponent<MeshRenderer>();
        counter = 11;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (detected)
        {
            Animator.SetBool("detected", true);
            meshrend.enabled = false;
            counter = counter - Time.deltaTime;
        }

        if (counter <= 0)
        {
            detected = false;
            counter = 11;
            Animator.SetBool("detected", false);
            meshrend.enabled = true;
        }


    }


    


}
