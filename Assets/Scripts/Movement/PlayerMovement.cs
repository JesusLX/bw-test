using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovement {
    public Stats.MovementST stats;

    private IMovementInput input;
    private Rigidbody rb;
    private IGroundDetection groundDetection;

    private bool isGrounded = true;
    private bool canMove = true;

    public GameObject groundDetectorGO;

    private void Start() {
        input = GetComponent<IMovementInput>();
        rb = GetComponent<Rigidbody>();
        groundDetection = groundDetectorGO.GetComponent<IGroundDetection>();
    }

    private void Update() {
        isGrounded = groundDetection.IsGrounded();

        if (isGrounded && input.JumpInput()) {
            Jump();
        }
    }

    private void FixedUpdate() {
        TryMove();
    }

    public void Init(ICharacter character) {
        Stats stats = character.Stats;
        UpdateStats(stats);
        character.OnStatsChanged.AddListener(UpdateStats);
    }

    public void UpdateStats(Stats stats) {
        this.stats = stats.Movement;
    }

    private void Jump() {
        rb.AddForce(Vector3.up * stats.JumpForce, ForceMode.Impulse);
    }

    public void UpdateCanMove(bool can) {
        canMove = can;
    }

    public void TryMove() {
        if (canMove && isGrounded) {
            Vector3 movement = input.GetMovementInput();
            movement *= stats.MoveSpeed;

            // Mantener la velocidad vertical actual al saltar
            Vector3 currentVelocity = rb.velocity;
            movement.y = currentVelocity.y;

            rb.velocity = movement;
        }
    }
}