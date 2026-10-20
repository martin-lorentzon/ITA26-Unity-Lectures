
using UnityEngine;

public class PivotLook : MonoBehaviour
{
    public float mouseSensitivity = 400f;
    public float smoothTime = 0.1f;

    // Private Variables
    private Vector2 targetRotation;
    private Vector2 currentRotation;
    private Vector2 rotationVelocity;

    void Update()
    {
        if (Input.GetMouseButton(0))  // User is controlling the camera
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            targetRotation.x += Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;
            targetRotation.y -= Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        // Smoothly rotate towards the target rotation
        currentRotation = Vector2.SmoothDamp(
            currentRotation,
            targetRotation,
            ref rotationVelocity,
            smoothTime
        );

        // Rotate the object
        transform.eulerAngles = new Vector3(
            currentRotation.y,
            currentRotation.x,
            0f
        );
    }
}
