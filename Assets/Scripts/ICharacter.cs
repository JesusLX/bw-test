using System.Transactions;
using UnityEngine;
using UnityEngine.Events;

public interface ICharacter {
    public Stats Stats { get; set; }
    public UnityEvent<Stats> OnStatsChanged { get; }
    public Transform Transform { get; }
    public void Init();

    public void AddWeapon(IWeapon weapon);
    void Die();
     void Hit(float damage);
}