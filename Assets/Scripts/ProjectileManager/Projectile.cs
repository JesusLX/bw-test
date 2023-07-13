using bw_test.ParticlesPool;
using bw_test.Pools;
using bw_test.ProjectilePool;
using System.Collections;
using UnityEngine;
namespace bw_test.Projectile {

    public class Projectile : PoolItem, IProjectile {

        public string ExplosionPSKey;

        public float moveSpeed = 5f;
        private float maxLifeTime = 10f;
        private Countdown _countdown;
        private Coroutine _coroutineMoveForward;
        private float damage;
        ICharacter shooter;

        private IEnumerator MoveForward() {
            while (true) {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
                yield return null;
            }
        }
        private void OnTriggerEnter(Collider other) {
            ICharacter target;
            if (other.TryGetComponent<ICharacter>(out target)) {
                target.Hit(damage,shooter);
            }
            Kill();
        }
       
        public virtual void TimeOut() {
            Kill();
        }
        public void Shoot() {
            _countdown = new Countdown(maxLifeTime);

            _coroutineMoveForward = StartCoroutine(MoveForward());
            _countdown.OnTimeOut = (TimeOut);
            StartCoroutine(_countdown.StartCountdown());
        }
        public override void Kill() {
            PSManager.instance.Play(ExplosionPSKey, null, transform.position, Quaternion.identity);
            StopCoroutine(_coroutineMoveForward);
            _countdown.StopCountdown();
            _countdown.OnTimeOut -= (TimeOut);
            base.Kill();

        }

        public void SetDamage(float damage) {
            this.damage = damage;
        }

        public void SetShooter(ICharacter shooter) {
            this.shooter = shooter;
        }
    }
}
