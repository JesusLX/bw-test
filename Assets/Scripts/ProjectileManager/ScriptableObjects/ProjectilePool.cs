using UnityEngine;
using bw_test.Pools;

namespace bw_test.ProjectilePool {

    [CreateAssetMenu(fileName = "New Projectile pool", menuName = "bw_test/ProjectilePool")]
    public class ProjectilePool : PoolSystemBase {
        public override PoolItem Play(Transform parent, Vector3 position, Quaternion rotation) {
            PoolItem ps = base.Play(parent, position, rotation);
            ps = this.ShootProjectile(ps);
            return ps;
        }
        public override PoolItem Play(Vector3 position, Quaternion rotation) {
            PoolItem ps = base.Play(position, rotation);
            ps = this.ShootProjectile(ps);
            return ps;
        }
        public override PoolItem Play(Transform parent) {
            PoolItem ps = base.Play(parent);
            ps = this.ShootProjectile(ps);
            return ps;
        }

        public PoolItem ShootProjectile(PoolItem poolItem) {
            poolItem.GetComponent<IProjectile>().Shoot();
            return poolItem;
        }
    }
}
