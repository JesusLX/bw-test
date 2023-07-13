namespace bw_test.ProjectilePool {
    public interface IProjectile {
        void SetDamage(float damage);
        void SetShooter(ICharacter shooter);
        public void Shoot();
    }
}