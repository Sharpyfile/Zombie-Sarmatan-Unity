using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivityX = 15.0f;
    public float sensitivityY = 15.0f;

    public float minimumY = -60.0f;
    public float maximumY = 60.0f;
    float xRotation = 0.0f;
    public Transform playerBody;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   
    }

    void Update()
    {
        LookAround();
    }

    private void LookAround()
    {
        float rotationX = Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime;
        float rotationY = Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime;

        xRotation -= rotationY;
        xRotation = Mathf.Clamp(xRotation, minimumY, maximumY);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * rotationX);
    }
}
