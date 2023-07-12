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

        private IEnumerator MoveForward() {
            while (true) {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
                yield return null;
            }
        }

        private void OnCollisionEnter(Collision collision) {
            // Realizar acciones adicionales al colisionar con otro objeto (opcional)
            Debug.Log("Objeto colisionado: " + collision.gameObject.name);

            // Detener la corrutina de movimiento
            StopCoroutine(_coroutineMoveForward);
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
            //PSManager.instance.Play(ExplosionPSKey, null, transform.position, Quaternion.identity);
            _countdown.StopCountdown();
            _countdown.OnTimeOut -= (TimeOut);
            base.Kill();

        }
    }
}