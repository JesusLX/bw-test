using bw_test.Movement;
using bw_test.ParticlesPool;
using bw_test.Pools;
using bw_test.PowerUps;
using bw_test.ST;
using bw_test.Weapons;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace bw_test.Characters {
    public class Enemy : PoolItem, ICharacter {
        public string SpawnPSKey;
        public string DiePSKey;

        #region ICharacter
        [SerializeField] private Stats basicStats;
        private Stats currentStats;

        public Stats Stats { get => currentStats; set => currentStats = value; }
        private UnityEvent<Stats> onStatsChanged = new UnityEvent<Stats>();
        public Transform Transform => this.transform;
        #endregion
        
        public UnityEvent<Stats> OnStatsChanged => onStatsChanged;

        private IMovement movementController;
        public List<IWeapon> weapons;

        void Start() {
            GetComponent<AutomaticMovement>().OnPlayerTooClose.AddListener(Attack);

        }

        /// <summary>
        /// Attack with all the weapons
        /// </summary>
        public void Attack() {
            weapons.ForEach(x => x.TryAttack());
        }

        #region ICharacter
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

        }

        public void Die(ICharacter assasing) {
            PSManager.instance.Play(DiePSKey, null, transform.position, Quaternion.identity);
            assasing.AddExp(
                Stats.Level.Experience
                );
            Kill();
        }

        public void AddExp(float experience) {
            Stats.Level.Experience += experience;
        }

        public void AddPowerUp(IPowerUp powerUp) { }

        public void UpdateStats(Stats stats) {
            this.Stats += stats;
            OnStatsChanged?.Invoke(this.Stats);
        }
        #endregion
    } 
}
