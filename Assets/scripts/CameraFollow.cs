using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float mouseSensitivity = 100f;
    private float yRotation = 0f;
    private float xRotation = 0f;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        // Lock the vertical rotation within a specific range
        xRotation = Mathf.Clamp(xRotation, -45f, 45f);
        xRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation + mouseX, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
    }


}