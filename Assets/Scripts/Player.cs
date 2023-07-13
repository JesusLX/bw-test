using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, ICharacter
{
    public List<IWeapon> weapons;
    [SerializeField]private Stats stats;

    public Stats Stats { get => stats; set => stats = value; }
    private UnityEvent<Stats> onStatsChanged;
    public UnityEvent<Stats> OnStatsChanged { get { return onStatsChanged; } }

    private void Awake() {
        onStatsChanged = new UnityEvent<Stats>();
    }
    private void Start() {
        weapons = new();
        foreach (var weapon in GetComponentsInChildren<IWeapon>()) {
            AddWeapon(weapon);
        }
        GetComponent<IMovement>().Init(this);
    }

    public void AddWeapon(IWeapon weapon) {
        weapon.Init(this);
        weapons.Add(weapon);

    }


}
