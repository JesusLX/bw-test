using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using bw_test.Projectile;

namespace bw_test.ProjectilePool {
    public partial class ProjectileManager : Singleton<ProjectileManager> {
        public List<ProjectilePool> projectilePools;

        [Header("Test")]
        public string testId;
        public bool testMultishootAtStart = false;
        private Coroutine testMultishootCor;

        private void Start() {
            projectilePools ??= new();
            if (testMultishootAtStart) {
                testMultishootCor = StartCoroutine(Multishot());
            }
        }

        private IEnumerator Multishot() {
            while (testMultishootAtStart) {
                TestPlay();
                yield return 0f;
            }
        }
        /// <summary>
        /// Test Function "Play" with the position and rotation of this manager using this.testId to select the Projectile to play
        /// </summary>
        [ContextMenu("Test/Play")]
        public void TestPlay() {
            Play(
                testId,
                null ,
                transform.position, 
                transform.rotation,0);
        }
        /// <summary>
        /// Test Function "Play" using this manager transform as parent and this.testId to select the Projectile to play
        /// </summary>
        [ContextMenu("Test/PlayAttached")]
        public void TestPlayAttached() {
            Play(testId, gameObject.transform,Vector3.zero,Quaternion.identity,0);
        }

        /// <summary>
        /// Invoke the particle system using the pool
        /// </summary>
        /// <param name="poolId">Id to find the pool</param>
        /// <param name="parent">Transform nullable to set as the Projectile Parent</param>
        /// <param name="position">Vector3 where to position and Play the Projectile</param>
        /// <param name="rotation">Rotation of the Projectile</param>
        /// <returns>The Projectile invoked</returns>
        public IMunition Play(string poolId, Transform parent, Vector3 position, Quaternion rotation, float damage) {
            if(position == null) {
                position = Vector3.zero;
            }
            ProjectilePool pool = FindPool(poolId);
            var ps = pool.Play(parent, position, rotation);
            ps.GetComponent<IMunition>().SetDamage(damage);
            return ps.GetComponent<IMunition>();
        }

        private ProjectilePool FindPool(string poolId) {
            ProjectilePool pool = projectilePools.Find(pool => pool.Id == poolId);
            return pool;
        }
    }
}
