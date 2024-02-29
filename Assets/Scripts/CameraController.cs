using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float mouse_sensitivity = 2f;

    private float rotationY = 0.0f;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotationY -= mouseY * mouse_sensitivity;
        rotationY = Mathf.Clamp(rotationY, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotationY, 0, 0);
        transform.parent.Rotate(Vector3.up * mouseX * mouse_sensitivity);
    }
}
