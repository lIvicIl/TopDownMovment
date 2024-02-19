using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float zoomSpeed = 10f;
    public float minY = 5f; // Minimum altitude
    public float maxY = 50f; // Maximum altitude

    void Update()
    {
        // Camera movement on X and Z axes
        float horizontal = Input.GetAxisRaw("Horizontal"); //is A/D keys
        float vertical = Input.GetAxisRaw("Vertical"); //is W/S keys
        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        
        transform.position += movement * moveSpeed * Time.deltaTime;

        // Camera zoom - move along Y-axis on scroll
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        MoveCameraOnYAxis(scroll);
    }

    private void MoveCameraOnYAxis(float scrollAmount)
    {
        // Calculate new Y position based on scroll input
        float newY = transform.position.y - scrollAmount * zoomSpeed;
        newY = Mathf.Clamp(newY, minY, maxY); // Ensure Y stays within bounds
        
        // Update camera position
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}





