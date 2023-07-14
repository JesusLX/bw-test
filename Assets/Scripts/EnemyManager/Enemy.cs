using bw_test.ParticlesPool;
using bw_test.Pools;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class Enemy : PoolItem, ICharacter {
    public string SpawnPSKey;
    public string DiePSKey;


    [SerializeField] private Stats basicStats;
     private Stats currentStats;

    public Stats Stats { get => currentStats; set => currentStats = value; }
    private UnityEvent<Stats> onStatsChanged = new UnityEvent<Stats>();
    public UnityEvent<Stats> OnStatsChanged => onStatsChanged;

    public Transform Transform => this.transform;

    private IMovement movementController;
    public List<IWeapon> weapons;



    void Start() {
       
        GetComponent<AutomaticMovement>().OnPlayerTooClose.AddListener(PlayerTooClose);
        
    }


    public void Init() {
        Stats = ScriptableObject.CreateInstance<Stats>() + basicStats;

        movementController = GetComponent<IMovement>();
        movementController.Init(FindObjectOfType<Player>());

        weapons = new List<IWeapon>(GetComponentsInChildren<IWeapon>());
        foreach (var weapon in weapons) {
            AddWeapon(weapon);
        }

        PSManager.instance.Play(SpawnPSKey, null, transform.position, Quaternion.LookRotation(Vector3.up));

    }

    public void AddWeapon(IWeapon weapon) {
        weapon.Init(this);
    }

    public void Hit(float damage, ICharacter damagedTo) {
        Stats.Health.CurrentHealth -= damage;
        if (Stats.Health.CurrentHealth <= 0) {
            Die(damagedTo);
        }
        Debug.Log(Stats.Health.CurrentHealth);

    }

    public void Die(ICharacter assasing) {
        PSManager.instance.Play(DiePSKey, null, transform.position, Quaternion.identity);
        assasing.AddExp(
            Stats.Level.Experience
            );
        Debug.Log("MORIO");
        Kill();
    }

    public void AddExp(float experience) {
        Stats.Level.Experience += experience;
    }

    public void AddPowerUp(IPowerUp powerUp) {
        
    }

    public void UpdateStats(Stats stats) {
        this.Stats += stats;
        OnStatsChanged?.Invoke(this.Stats);
    }

    public void PlayerTooClose() {
        weapons.ForEach(x =>x.TryAttack());
    }
}
