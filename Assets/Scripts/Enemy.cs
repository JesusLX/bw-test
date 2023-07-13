using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour, ICharacter {
    public float rotationSpeed = 2f;
    [SerializeField]private Stats basicStats;

    public Stats Stats { get => basicStats; set => basicStats = value; }

    public UnityEvent<Stats> OnStatsChanged { get; }



    void Start()
    {

    }

    void Update()
    {
        Player player = FindObjectOfType<Player>();

        transform.position += (player.transform.position - transform.position) * Time.deltaTime;

        LookAt(player);
    }
    private void LookAt(Player player) {
        Vector3 targetDirection = player.transform.position - transform.position;
        targetDirection.y = 0f; 

        if (targetDirection != Vector3.zero) {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    public void AddWeapon(IWeapon weapon) {
    }
}
