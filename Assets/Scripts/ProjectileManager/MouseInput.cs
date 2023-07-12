using UnityEngine;

public class MouseInput : MonoBehaviour, IShootInput {
    public bool ShootButtonPressed() {
        return Input.GetMouseButton(0);
    }
}