using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class AutomaticMovement : Movement {

    private ICharacter player;
    public float rotationSpeed = 2f;
    private bool notTooClose;
    public UnityEvent OnPlayerTooClose;
 
    void Update() {
        TryMove();
    }

    public override void Init(ICharacter player) {
        stats = player.Stats.Movement;
        this.player = player;
        UpdateCanMove(true);
    }
    private IEnumerator TooCloseAlert() {
        while (true) {
            if (!notTooClose) {
                OnPlayerTooClose?.Invoke();
                yield return null;
            } else {
                yield return null;
            }
        }
    }
    public override void TryMove() {
        if (canMove && player != null) {
            LookAt(player.Transform);

            float distance = Vector3.Distance(transform.position, player.Transform.position);
            if (notTooClose = (distance > 1)) {
                transform.position += transform.forward * stats.MoveSpeed * Time.deltaTime;
            } else if (distance <= 1) {

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
    internal override void OnEnableEvents() {
        base.OnEnableEvents();
        StartCoroutine(TooCloseAlert());
    }
    internal override void OnDisableEvents() {
        base.OnDisableEvents();
        StopCoroutine(TooCloseAlert());
    }
}
