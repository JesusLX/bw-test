using bw_test.PowerUps;
using bw_test.ST;
using bw_test.Weapons;
using UnityEngine;
using UnityEngine.Events;

namespace bw_test.Characters {
    public interface ICharacter {
        public Stats Stats { get; set; }
        public UnityEvent<Stats> OnStatsChanged { get; }
        public Transform Transform { get; }
        public void Init();

        public void AddWeapon(IWeapon weapon);
        void Hit(float damage, ICharacter damagedBy);
        void Die(ICharacter assasing);
        void AddExp(float experience);
        void AddPowerUp(IPowerUp powerUp);
        void UpdateStats(Stats stats);
    } 
}