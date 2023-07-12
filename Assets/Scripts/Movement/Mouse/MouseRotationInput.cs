using UnityEngine;

public class MouseRotationInput : MonoBehaviour, IRotationInput {
    public Vector2 GetRotationInput() {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        return new Vector2(mouseX, mouseY);
    }
}
