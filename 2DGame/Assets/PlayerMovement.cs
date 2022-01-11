using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    public Rigidbody2D camrb;
    public Camera cam;

    Vector2 movement;


    Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        // Get methods for coordinates
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Method to find where on the screen the mouse is
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        // Player movement
        // Moves the rigid body on the character using inbuilt unity functions
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        // Makes the player look at the camera (roughly)
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 13.5f;
        //rb.rotation = angle;

        // Moves the camera to wherever the player is
        camrb.MovePosition(rb.position);
    }
}
