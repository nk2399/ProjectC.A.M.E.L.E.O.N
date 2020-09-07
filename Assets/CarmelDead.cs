using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarmelDead : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
            
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }
}
