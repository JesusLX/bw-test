using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, ICharacter, ITimeAffected {
    public HashSet<IWeapon> weapons;
    [SerializeField] private Stats basicStats;
    private Stats currentStats;

    public Stats Stats { get => currentStats; set => currentStats = value; }
    public UnityEvent<Stats.LevelST> OnExperienceChanged = new UnityEvent<Stats.LevelST>();
    private UnityEvent<Stats> onStatsChanged = new UnityEvent<Stats>();
    public UnityEvent<Stats> OnStatsChanged => onStatsChanged;
    public Transform Transform => transform;

    private void OnEnable() {
        onStatsChanged = new UnityEvent<Stats>();
        AttachTimeEvents();
    }
    private void OnDisable() {
        DetachTimeEvents();
    }



    private void Start() {
    }

    public void Init() {
        Stats = ScriptableObject.CreateInstance<Stats>() + basicStats;
        weapons = new HashSet<IWeapon>(GetComponentsInChildren<IWeapon>());
        foreach (var weapon in weapons) {
            AddWeapon(weapon);
        }
        GetComponent<IMovement>().Init(this);
    }

    public void AddWeapon(IWeapon weapon) {
        weapon.Init(this);
        weapons.Add(weapon);
    }

    public void Hit(float damage, ICharacter assasing) {
        Debug.Log("DUELEEEE");
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

    public void AddPowerUp(IPowerUp powerUp) {
        GetComponent<PowerUpController>().AddPowerUp(powerUp);
    }

    public void UpdateStats(Stats stats) {
        Debug.Log(stats);
        Debug.Log( Stats);
        this.Stats += stats;
        OnStatsChanged?.Invoke(this.Stats);
    }

    #region ITimeAffected
    public void OnPlayTimeStarts() {
        Debug.Log("VAMOOOOOOOS");
        Init();
    }

    public void OnPlayTimeRestore() {
    }

    public void OnPlayTimeStops() {
    }

    public void AttachTimeEvents() {
        TimeManager.instance.OnPlayTimeStart.AddListener(OnPlayTimeStarts);
        TimeManager.instance.OnPlayTimeStop.AddListener(OnPlayTimeStops);
        TimeManager.instance.OnPlayTimeRestore.AddListener(OnPlayTimeRestore);
    }

    public void DetachTimeEvents() {
        TimeManager.instance.OnPlayTimeStart.RemoveListener(OnPlayTimeStarts);
        TimeManager.instance.OnPlayTimeStop.RemoveListener(OnPlayTimeStops);
        TimeManager.instance.OnPlayTimeRestore.RemoveListener(OnPlayTimeRestore);
    }

    #endregion
}
