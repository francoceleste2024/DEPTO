using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public float gravity = 20f;
    public float mouseSensitivity = 100f;

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    private float verticalVelocity = 0f;

    private float rotationY = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // Oculta y bloquea el cursor
    }

    void Update()
    {
        // Mouse input para girar el personaje
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        transform.Rotate(0f, mouseX, 0f);

        // Movimiento horizontal (WASD)
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 forward = transform.forward;
        Vector3 right = transform.right;
        Vector3 move = (forward * moveZ + right * moveX).normalized;

        if (controller.isGrounded)
        {
            verticalVelocity = -1f; // Asegura que el personaje se mantenga en el suelo

            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        moveDirection = move * moveSpeed;
        moveDirection.y = verticalVelocity;

        controller.Move(moveDirection * Time.deltaTime);
    }
}
