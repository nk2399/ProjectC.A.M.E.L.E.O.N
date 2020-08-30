using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UnvisableForUnsiable : MonoBehaviour
{
    public GameObject body;
    Renderer rend;
    ReflectionProbe reflectionprobe;
    public GameObject reflection;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        reflectionprobe = reflection.GetComponent<ReflectionProbe>();
        rend = body.GetComponent<Renderer>();
        rend.enabled = false;
        reflectionprobe.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        transform.localRotation = player.transform.localRotation;

        if (Input.GetKeyDown(KeyCode.G))
        {
            rend.enabled = true;
            reflectionprobe.enabled = true;
        }

        if (Input.GetKeyUp(KeyCode.G))
        {
            rend.enabled = false;
            reflectionprobe.enabled = false;

        }
    }
}
