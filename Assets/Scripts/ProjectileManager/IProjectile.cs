using bw_test.Characters;

namespace bw_test.ProjectilePool {
    public interface IMunition {
        void SetDamage(float damage);
        void SetShooter(ICharacter shooter);
        public void Shoot();
    }
}