using bw_test.ProjectilePool;
using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.GraphicsBuffer;

public class Gun : Weapon {
    private ShakeObject recoil;

    private void Start() {
        actionInput = GetComponent<IShootInput>();
        recoil = GetComponent<ShakeObject>();
    }

    private void Update() {
        TryAttack();
    }

    public override bool TryAttack() {
        if (actionInput.ShootButtonPressed()) {
            if (attackCor == null) {
                attackCor = StartCoroutine(AttackCor());
            }
        }
        return true;
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
