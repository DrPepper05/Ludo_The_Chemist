using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolllow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform cameraPosition;

    public Vector3 cameraOffset;
    public float sensitivity = 2f ;
    private Vector2 rotation = Vector2.zero;
    public float rotationLimit = 90f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        // Capture mouse input for camera rotation
        Vector3 cameraForward = cameraPosition.transform.forward;


        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        this.transform.position = cameraPosition.position + cameraOffset.z * cameraForward ;
        // Rotate the camera vertically
        rotation.y += mouseX;
        rotation.x -= mouseY;
        rotation.x = Mathf.Clamp(rotation.x, -rotationLimit, rotationLimit);
        this.transform.parent.transform.rotation = Quaternion.Euler(0, rotation.y, 0f);
        this.transform.rotation = Quaternion.Euler(rotation.x,0f, 0f);
    }
}
