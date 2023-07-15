using bw_test.Inputs;
using bw_test.ProjectilePool;
using System.Collections;
using UnityEngine;

namespace bw_test.Weapons {
    public class Gun : Weapon {
        private ShakeObject recoil;
        public bool InUpdate = true;

        private void Start() {
            actionInput = GetComponent<IShootInput>();
            recoil = GetComponent<ShakeObject>();
        }

        private void Update() {
            if (InUpdate) {
                TryAttack();
            }
        }

        #region Weapon
        public override void TryAttack() {

            if (actionInput.ShootButtonPressed()) {
                if (attackCor == null) {
                    attackCor = StartCoroutine(AttackCor());
                }
            }
        }
        public override void Attack() {

            recoil.Fire();
            var projectile = ProjectileManager.instance.Play(projectileKey, null, stats.ApplyShootMargenError(attackStartPosition.position), attackStartPosition.rotation, stats.Damage);
            projectile.SetShooter(attacker);
        }
        internal override IEnumerator AttackCor() {
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
    } 
    #endregion

}