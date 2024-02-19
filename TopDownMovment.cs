using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TopDownController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float zoomSpeed = 10f;
    public float minY = 5f; // Minimum altitude for the camera
    public float maxY = 20f; // Maximum altitude for the camera

    private Rigidbody rb;
    private Camera cam;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Ensure the player capsule has a Rigidbody component
        cam = GetComponentInChildren<Camera>(); // Automatically finds the Camera component in child objects
    }

    void Update()
    {
        // Capture movement input
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical).normalized * moveSpeed;

        // Apply movement in FixedUpdate for physics calculation
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        // Camera zoom - adjust Y position based on scroll, directly affecting the camera's transform
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        MoveCameraOnYAxis(scroll);
    }

    private void MoveCameraOnYAxis(float scrollAmount)
    {
        // Ensure the camera does not move below the minY or above the maxY
        Vector3 cameraPosition = cam.transform.position;
        float newY = Mathf.Clamp(cameraPosition.y - scrollAmount * zoomSpeed, minY, maxY);
        cam.transform.position = new Vector3(cameraPosition.x, newY, cameraPosition.z);
    }
}






