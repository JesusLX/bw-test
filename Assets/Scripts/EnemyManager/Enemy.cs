using bw_test.ParticlesPool;
using bw_test.Pools;
using System;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class Enemy : PoolItem, ICharacter {
    public string DiePSKey;


    [SerializeField] private Stats basicStats;
     private Stats currentStats;

    public Stats Stats { get => currentStats; set => currentStats = value; }

    public UnityEvent<Stats> OnStatsChanged { get; }

    public Transform Transform => this.transform;

    private IMovement movementController;



    void Start() {
    }


    public void Init() {
        movementController = GetComponent<IMovement>();

        movementController.Init(FindObjectOfType<Player>());
        Stats = new Stats() + basicStats;

    }



    public void AddWeapon(IWeapon weapon) {
    }

    public void Hit(float damage) {
        Stats.Health.CurrentHealth -= damage;
        if (Stats.Health.CurrentHealth <= 0) {
            Die();
        }
        Debug.Log(Stats.Health.CurrentHealth);

    }

    public void Die() {
        PSManager.instance.Play(DiePSKey, null, transform.position, Quaternion.identity);

        Debug.Log("MORIO");
        Kill();
    }
}
