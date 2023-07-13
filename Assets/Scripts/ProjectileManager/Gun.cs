using bw_test.ProjectilePool;
using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.GraphicsBuffer;

public class Gun : MonoBehaviour, IWeapon {
    private IShootInput mouseInput;
    public string projectileKey;
    public Transform shootPosition;
    public bool canShoot = true;
    public Stats.AttackST stats;

    private Coroutine shootCor;

    private ShakeObject recoil;

    private void Start() {
        mouseInput = GetComponent<IShootInput>();
        recoil = GetComponent<ShakeObject>();
    }

    private void Update() {
        TryAttack();
    }

    public void Init(Player player) {
         player.OnStatsChanged.AddListener(UpdateStats);
        UpdateStats(player.Stats);

    }
    public void UpdateStats(Stats stats) {
        this.stats = stats.Attack;
    }

    public bool TryAttack() {
        if (mouseInput.ShootButtonPressed()) {
            if(shootCor == null) {
                shootCor = StartCoroutine(ShootCor()); 
            }
        }
        return true;
    }
    public void Shoot() {
        recoil.Fire();
        ProjectileManager.instance.Play(projectileKey, null, stats.ApplyShootMargenError(shootPosition.position), shootPosition.rotation, stats.Damage);

    }
    private IEnumerator ShootCor() {
        if (canShoot) {
            for (int i = 0; i < stats.Rafaga; i++) {
                if (canShoot) {
                    Shoot();
                } else {
                    break;
                }
                if (i != stats.Rafaga - 1) {
                    yield return new WaitForSeconds(stats.RafagaCountdown);
                }
            }
            yield return new WaitForSeconds(stats.ShootCountdown);
        }
        shootCor = null;

    }
}
