using UnityEngine;

public class ShootFreeInput : MonoBehaviour, IShootInput {
    public bool ShootButtonPressed() {
        return true;
    }
}