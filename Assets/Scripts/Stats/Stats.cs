using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stat", menuName = "bw_test/Stats")]
public class Stats : ScriptableObject {
    [Serializable]
    public struct HealthST {

        [SerializeField] private float maxHealth;
        [SerializeField] private float currentHealth;
        public float MaxHealth { get => maxHealth; set => maxHealth = value; }
        public float CurrentHealth { get => currentHealth; set => currentHealth = value; }
        public static Stats.HealthST operator +(Stats.HealthST a, Stats.HealthST b) {
            a.MaxHealth += b.MaxHealth;
            a.CurrentHealth += b.CurrentHealth;
            return a;
        }
    }
    [Serializable]
    public struct MovementST {

        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpForce;
        public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
        public float JumpForce { get => jumpForce; set => jumpForce = value; }
        public static Stats.MovementST operator +(Stats.MovementST a, Stats.MovementST b) {
            a.moveSpeed += b.moveSpeed;
            a.jumpForce += b.jumpForce;
            return a;
        }
    }
    [Serializable]
    public struct AttackST {

        [SerializeField] private float damage;
        [SerializeField] private float rafaga;
        [SerializeField] private float rafagaCountdown;
        [SerializeField] private float shootCountdown;
        [SerializeField] private Vector3 shootMargenError;

        public float Damage { get => damage; set => damage = value; }
        public float RafagaCountdown { get => rafagaCountdown; set => rafagaCountdown = value; }
        public float Rafaga { get => rafaga; set => rafaga = value; }
        public float ShootCountdown { get => shootCountdown; set => shootCountdown = value; }
        public Vector3 ShootMargenError { get => shootMargenError; set => shootMargenError = value; }

        public Vector3 ApplyShootMargenError(Vector3 positionToApply) {
            var rX = UnityEngine.Random.Range(-this.ShootMargenError.x, this.ShootMargenError.x);
            var rY = UnityEngine.Random.Range(-this.ShootMargenError.y, this.ShootMargenError.y);
            var rZ = UnityEngine.Random.Range(-this.ShootMargenError.z, this.ShootMargenError.z);
            Vector3 errorPoint = new Vector3(
                positionToApply.x + rX,
                positionToApply.y + rY,
                positionToApply.z + rZ
                );
            return errorPoint;
        }
        public static Stats.AttackST operator +(Stats.AttackST a, Stats.AttackST b) {
            a.Damage += b.Damage;
            a.Rafaga += b.Rafaga;
            a.RafagaCountdown += b.RafagaCountdown;
            a.ShootCountdown += b.ShootCountdown;
            a.ShootMargenError += b.ShootMargenError;
            return a;
        }
    }

    public Stats.HealthST Health;
    public Stats.MovementST Movement;
    public Stats.AttackST Attack;

    public static Stats operator +(Stats a, Stats b) {
        a.Health += b.Health;
        a.Movement += b.Movement;
        a.Attack += b.Attack;
        return a;
    }
}