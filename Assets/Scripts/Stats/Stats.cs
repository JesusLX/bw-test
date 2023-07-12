using UnityEngine;

    [CreateAssetMenu(fileName = "New Stat", menuName = "bw_test/Stats")]
public class Stats : ScriptableObject {
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float rafaga;
    [SerializeField] private float rafagaCountdown;
    [SerializeField] private float shootCountdown;
    [SerializeField] private Vector3 shootMargenError;
    [SerializeField] private Vector3 margenErrorHit;

    public float RafagaCountdown { get => rafagaCountdown; set => rafagaCountdown = value; }
    public float Rafaga { get => rafaga; set => rafaga = value; }
    public float ShootCountdown { get => shootCountdown; set => shootCountdown = value; }
    public Vector3 ShootMargenError { get => shootMargenError; set => shootMargenError = value; }
    public float MaxHealth { get => maxHealth; set => maxHealth = value; }
    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public float JumpForce { get => jumpForce; set => jumpForce = value; }

    public Vector3 ApplyShootMargenError(Vector3 positionToApply) {
        var rX = Random.Range(-this.ShootMargenError.x, this.ShootMargenError.x);
        var rY = Random.Range(-this.ShootMargenError.y, this.ShootMargenError.y);
        var rZ = Random.Range(-this.ShootMargenError.z, this.ShootMargenError.z);
        Vector3 errorPoint = new Vector3(
            positionToApply.x + rX,
            positionToApply.y + rY,
            positionToApply.z + rZ
            );
        return errorPoint;
    }

    public static Stats operator +(Stats a, Stats b) {
        a.maxHealth += b.maxHealth;
        a.currentHealth += b.currentHealth;
        a.moveSpeed += b.moveSpeed;
        a.jumpForce += b.jumpForce;
        a.rafaga += b.rafaga;
        a.rafagaCountdown += b.rafagaCountdown;
        a.shootCountdown += b.shootCountdown;
        a.shootMargenError += b.shootMargenError;
        a.margenErrorHit += b.margenErrorHit;
        return a;
    }
}