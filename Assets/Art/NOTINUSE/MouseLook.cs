using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private float mouseX;
    private float mouseY;
    public Transform playerBody;
    private float xRotation;

    [SerializeField]
    private int mouseSensetivity;
    // Start is called before the first frame update
    void Start()
    {
        xRotation = 0f;
        mouseSensetivity = 500;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensetivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensetivity * Time.deltaTime;
       
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation,-90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
       
        playerBody.Rotate(Vector3.up * mouseX);
    }

}
