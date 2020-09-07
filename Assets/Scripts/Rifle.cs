using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    public Vector3 pickposition;
    public Vector3 pickrotation;
    public MeshRenderer rend;
    public Renderer rend2;
    public bool dead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            Destroy(gameObject);
        }
    }
}
