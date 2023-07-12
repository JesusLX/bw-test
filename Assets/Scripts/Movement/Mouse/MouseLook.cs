using UnityEngine;

public class MouseLook : MonoBehaviour {
    public float mouseSensitivity = 100f;

    private IRotationInput rotationInput;
    private Transform playerTransform;

    private float xRotation = 0f;

    private void Start() {
        rotationInput = GetComponent<IRotationInput>();
        playerTransform = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        Vector2 rotationInputValues = rotationInput.GetRotationInput();
        float mouseX = rotationInputValues.x * mouseSensitivity * Time.deltaTime;
        float mouseY = rotationInputValues.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerTransform.Rotate(Vector3.up * mouseX);
    }
}
