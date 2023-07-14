using System.Transactions;
using UnityEngine;
using UnityEngine.Events;

public interface ICharacter {
    public Stats Stats { get; set; }
    public UnityEvent<Stats> OnStatsChanged { get; }
    public Transform Transform { get; }
    public void Init();

    public void AddWeapon(IWeapon weapon);
    void Die(ICharacter assasing);
     void Hit(float damage, ICharacter damagedBy);
    void AddExp(float experience);
    void AddPowerUp(IPowerUp powerUp);
    void UpdateStats(Stats stats);
}