using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AutomaticMovement : MonoBehaviour, IMovement {

    private Stats.MovementST stats;
    private bool canMove = false;
    private ICharacter player;
    public float rotationSpeed = 2f;

    void Update() {
        TryMove();
    }

    public void Init(ICharacter player) {
        stats = player.Stats.Movement;
        this.player = player;
        UpdateCanMove(true);
    }

    public void TryMove() {
        if (canMove && player != null) {
            LookAt(player.Transform);
            Vector3 direction = (player.Transform.position - transform.position).normalized;

            float distance = Vector3.Distance(transform.position, player.Transform.position);
            if (distance > 1) {

                transform.position += direction * stats.MoveSpeed * Time.deltaTime;
            } else if (distance <= 1) {
                Debug.Log($"Objeto ha llegado al objetivo. {distance}");
            }
        }
    }
    private void LookAt(Transform player) {
        Vector3 targetDirection = player.transform.position - transform.position;
        targetDirection.y = 0f;

        if (targetDirection != Vector3.zero) {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
    public void UpdateCanMove(bool can) {
        canMove = can;
    }

    public void UpdateStats(Stats stats) {
        this.stats = stats.Movement;
    }
}
