using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {
    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("Jump")]
    public float jumpForce = 5f;
    private IMovementInput input;
    private Rigidbody rb;
    public GameObject groundDetectorGO;
    private IGroundDetection groundDetection;

    private bool isGrounded = true;


    private void Start() {
        input = GetComponent<IMovementInput>();
        rb = GetComponent<Rigidbody>();
        groundDetection = groundDetectorGO.GetComponent<IGroundDetection>();
    }
    private void Update() {
        isGrounded = groundDetection.IsGrounded();

        if (isGrounded && input.JumpInput()) {
            Jump();
        }
    }
    private void FixedUpdate() {
        if (isGrounded) {
            Vector3 movement = input.GetMovementInput();

            movement *= moveSpeed;

            // Mantener la velocidad vertical actual al saltar
            Vector3 currentVelocity = rb.velocity;
            movement.y = currentVelocity.y;

            rb.velocity = movement;
        }

    }
    private void Jump() {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public void Init(float moveSpeed,float jumpForce) {
        this.moveSpeed = moveSpeed;
        this.jumpForce = jumpForce;
    }
}
