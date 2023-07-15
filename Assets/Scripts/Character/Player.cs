using bw_test.Controllers;
using bw_test.Managers;
using bw_test.Movement;
using bw_test.PowerUps;
using bw_test.ST;
using bw_test.Weapons;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace bw_test.Characters {
    public class Player : MonoBehaviour, ICharacter, ITimeAffected {
        public HashSet<IWeapon> weapons;

        #region ICharacter
        [SerializeField] private Stats basicStats;
        private Stats currentStats;
        public Stats Stats { get => currentStats; set => currentStats = value; }
        private UnityEvent<Stats> onStatsChanged = new UnityEvent<Stats>();
        public Transform Transform => transform;
        #endregion

        public UnityEvent<Stats.LevelST> OnExperienceChanged = new UnityEvent<Stats.LevelST>();
        public UnityEvent<Stats> OnStatsChanged => onStatsChanged;

        public UnityEvent OnEnemyKilled = new();
        public UnityEvent OnDie = new();

        private void OnEnable() {
            onStatsChanged = new UnityEvent<Stats>();
            FindObjectOfType<LevelManager>().OnLevelUp.AddListener(LevelUp);
            AttachTimeEvents();
        }
        private void OnDisable() {
            DetachTimeEvents();
        }

        public void LevelUp(Stats.LevelST level) {
        }

        #region ICharacter
        public void Init() {
            transform.rotation = Quaternion.identity;
            Stats = ScriptableObject.CreateInstance<Stats>();
            UpdateStats(basicStats);
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
            Stats.Health.CurrentHealth -= damage;
            if (Stats.Health.CurrentHealth <= 0) {
                Die(assasing);
            }
            OnStatsChanged?.Invoke(Stats);
        }

        public void Die(ICharacter assasing) {
            GameManager.instance.GameOver();
            transform.DORotate(new Vector3(0, 0, 90f), 1f);
            OnDie?.Invoke();
        }

        public void AddExp(float experience) {
            OnEnemyKilled?.Invoke();
            Stats.Level.Experience += experience;
            Debug.Log("Exp " + Stats.Level.Experience);
            OnExperienceChanged?.Invoke(Stats.Level);
        }

        public void AddPowerUp(IPowerUp powerUp) {
            GetComponent<PowerUpController>().AddPowerUp(powerUp);
        }

        public void UpdateStats(Stats stats) {
            this.Stats += stats;
            OnStatsChanged?.Invoke(this.Stats);
        }
        #endregion

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

}