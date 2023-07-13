using UnityEngine;
using bw_test.Pools;

namespace bw_test.EnemyPool {

    [CreateAssetMenu(fileName = "New Particle pool", menuName = "bw_test/EnemyPool")]
    public class EnemyPool : PoolSystemBase {
        public override PoolItem Play(Transform parent, Vector3 position, Quaternion rotation) {
            PoolItem ps = base.Play(parent, position, rotation);
            ps = this.PlayEnemy(ps);
            return ps;
        }
        public override PoolItem Play(Vector3 position, Quaternion rotation) {
            PoolItem ps = base.Play(position, rotation);
            ps = this.PlayEnemy(ps);
            return ps;
        }
        public override PoolItem Play(Transform parent) {
            PoolItem ps = base.Play(parent);
            ps = this.PlayEnemy(ps);
            return ps;
        }

        public PoolItem PlayEnemy(PoolItem poolItem) {
            poolItem.GetComponent<Enemy>().Init();
            return poolItem;
        }
    }
}
