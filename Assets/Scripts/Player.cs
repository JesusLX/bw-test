using UnityEngine;

public class Player : MonoBehaviour
{
    public IWeapon weapon;
    public Stats stats;

    private void Start() {
        weapon = GetComponentInChildren<IWeapon>();
        weapon.Init(this);
    }
}
