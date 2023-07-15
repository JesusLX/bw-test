using bw_test.Characters;
using bw_test.Inputs;
using bw_test.Managers;
using bw_test.ProjectilePool;
using bw_test.ST;
using System.Collections;
using UnityEngine;

namespace bw_test.Weapons {
    public class Weapon : MonoBehaviour, IWeapon, ITimeAffected {
        internal IShootInput actionInput;
        public string projectileKey;
        public Transform attackStartPosition;
        public bool canAttack = true;
        public Stats.AttackST stats;

        internal Coroutine attackCor;

        internal ICharacter attacker;

        private void Start() {
            actionInput = GetComponent<IShootInput>();
        }
        private void OnEnable() {
            AttachTimeEvents();
        }
        private void OnDisable() {
            DetachTimeEvents();
        }
        virtual public void UpdateStats(Stats stats) {
            this.stats = stats.Attack;
        }

       
        virtual public void Attack() {
            var projectile = ProjectileManager.instance.Play(projectileKey, null, stats.ApplyShootMargenError(attackStartPosition.position), attackStartPosition.rotation, stats.Damage);
            projectile.SetShooter(attacker);
        }
        virtual internal IEnumerator AttackCor() {
            if (canAttack) {

                for (int i = 0; i < stats.Rafaga; i++) {
                    if (canAttack) {
                        Attack();
                    } else {
                        break;
                    }
                    if (i != stats.Rafaga - 1) {
                        yield return new WaitForSeconds(stats.RafagaCountdown);
                    }
                }
                yield return new WaitForSeconds(stats.ShootCountdown);
            }
            attackCor = null;

        }

        #region IWeapon
        virtual public void Init(ICharacter player) {
            player.OnStatsChanged.AddListener(UpdateStats);
            UpdateStats(player.Stats);
            attacker = player;

        }

        virtual public void TryAttack() {

            if (actionInput.ShootButtonPressed()) {
                if (attackCor == null) {
                    attackCor = StartCoroutine(AttackCor());
                }
            }
        }

        public void UpdateCanAttack(bool can) {
            canAttack = can;
        }
        #endregion


        #region ITimeAffected
        public void OnPlayTimeStarts() {
            UpdateCanAttack(true);
        }

        public void OnPlayTimeRestore() {
            UpdateCanAttack(true);
        }

        public void OnPlayTimeStops() {
            UpdateCanAttack(false);
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
