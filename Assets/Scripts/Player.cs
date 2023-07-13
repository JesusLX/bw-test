using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, ICharacter {
    public HashSet<IWeapon> weapons;
    [SerializeField] private Stats basicStats;
    private Stats currentStats;

    public Stats Stats { get => currentStats; set => currentStats = value; }
    public UnityEvent<Stats.LevelST> OnExperienceChanged = new UnityEvent<Stats.LevelST>();
    private UnityEvent<Stats> onStatsChanged = new UnityEvent<Stats>();
    public UnityEvent<Stats> OnStatsChanged => onStatsChanged;
    public Transform Transform => transform;

    private void Awake() {
        onStatsChanged = new UnityEvent<Stats>();
    }

    private void Start() {
        Init();
    }

    public void Init() {
        Stats = new Stats() + basicStats;
        weapons = new HashSet<IWeapon>(GetComponentsInChildren<IWeapon>());
        foreach (var weapon in weapons) {
            weapon.Init(this);
        }
        GetComponent<IMovement>().Init(this);
    }

    public void AddWeapon(IWeapon weapon) {
        weapon.Init(this);
        weapons.Add(weapon);
    }

    public void Hit(float damage, ICharacter assasing) {
        Stats.Health.CurrentHealth -= damage;
        if (Stats.Health.CurrentHealth <= 0) {
            Die(assasing);
        }
    }

    public void Die(ICharacter assasing) {
        Debug.Log("MURIO");
    }

    public void AddExp(float experience) {
        Stats.Level.Experience += experience;
        OnExperienceChanged?.Invoke(Stats.Level);
    }
}
