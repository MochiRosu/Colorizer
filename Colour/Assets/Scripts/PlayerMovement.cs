using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 180f;

    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        RotatePlayer();
    }

    void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        movement.Normalize(); // Ensures diagonal movement isn't faster

        // Move the player in the desired direction
        characterController.Move(movement * speed * Time.deltaTime);
    }

    void RotatePlayer()
    {
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        // Rotate the player around the Y-axis
        transform.Rotate(Vector3.up * rotation);
    }
}
