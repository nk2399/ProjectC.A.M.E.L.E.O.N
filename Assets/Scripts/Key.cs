using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    public Collider col;
    int x;
    // Start is called before the first frame update
    void Start()
    {
       // col = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (x==0)
        {
            col.enabled = false;
        }


    }
}
