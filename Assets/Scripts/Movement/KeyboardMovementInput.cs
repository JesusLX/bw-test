using UnityEngine;

public class KeyboardMovementInput : MonoBehaviour, IMovementInput {
    public Vector3 GetMovementInput() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        movement = transform.forward * movement.z + transform.right * movement.x;
        movement.Normalize();

        return movement;
    }
    public bool JumpInput() {
        return Input.GetKeyDown(KeyCode.Space);
    }
}