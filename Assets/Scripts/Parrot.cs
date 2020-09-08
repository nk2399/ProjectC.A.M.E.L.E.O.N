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
    int val;
    public GameObject player;
    public AudioSource audiomeneger;
    public AudioClip alarm;
    public AudioClip parrot;

    // Start is called before the first frame update
    void Start()
    {
        meshrend = mesh.GetComponent<MeshRenderer>();
        val = 25;
        counter = val;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (detected)
        {

            Animator.SetBool("detected", true);
            meshrend.enabled = false;
            counter = counter - Time.deltaTime;
            audiomeneger.PlayOneShot(alarm);
            audiomeneger.PlayOneShot(parrot);
        }

        if (counter <= 0)
        {
            detected = false;
            counter = val;
            Animator.SetBool("detected", false);
            meshrend.enabled = true;
            player.GetComponent<CarmelAngain>().blackspider01 = 1;
            player.GetComponent<CarmelAngain>().blackspider02 = 1;
            player.GetComponent<CarmelAngain>().blackspider03 = 1;
            player.GetComponent<CarmelAngain>().brownpider01 = 1;
            player.GetComponent<CarmelAngain>().brownpider02 = 1;
            audiomeneger.Pause();
        }


    }


    


}
