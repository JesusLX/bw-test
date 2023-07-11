using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    public float rotationSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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
}
