using UnityEngine;

namespace bw_test.Inputs {
    public class MouseInput : MonoBehaviour, IShootInput {
        public bool ShootButtonPressed() {
            return Input.GetMouseButton(0);
        }
    } 
}