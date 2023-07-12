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

    private Player player;
    private Coroutine shootCor;

    private void Start() {
        mouseInput = GetComponent<IShootInput>();
    }

    private void Update() {
        TryAttack();
    }

    public void Init(Player player) {
        this.player = player;
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
        ProjectileManager.instance.Play(projectileKey, null, player.stats.ApplyShootMargenError(shootPosition.position), shootPosition.rotation);

    }
    private IEnumerator ShootCor() {
        if (canShoot) {
            for (int i = 0; i < player.stats.Rafaga; i++) {
                if (canShoot) {
                    Shoot();
                } else {
                    break;
                }
                if (i != player.stats.Rafaga - 1) {
                    yield return new WaitForSeconds(player.stats.RafagaCountdown);
                }
            }
            yield return new WaitForSeconds(player.stats.ShootCountdown);
        }
        shootCor = null;

    }
}
