using UnityEngine;

namespace bw_test.Inputs {
    public class ShootFreeInput : MonoBehaviour, IShootInput {
        public bool ShootButtonPressed() {
            return true;
        }
    } 
}