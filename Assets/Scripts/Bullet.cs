using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody bullet;
    float speed;
    private int bulletlifespan;
    // Start is called before the first frame update
    void Start()
    {
        bulletlifespan = 5;
        speed = 200;
        bullet = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
        bullet.AddForce(bullet.transform.forward * speed);

    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject, bulletlifespan);
    }

   
}

