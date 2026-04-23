using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public abstract class EnemyClass : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float rotationSpeed = 45f;
    [SerializeField] private float atackDistance = 8;



    void Update()
    {
        lookAtPlayer();
        AttackPlayer();
    }
    private void lookAtPlayer()
    {
        float playerDistance = Vector2.Distance(transform.position, playerTransform.position);
        if (playerTransform != null && playerDistance <= atackDistance)
        {
            Vector2 direction = playerTransform.position - transform.position;
            transform.up = direction;
        }
        else
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }
    public abstract void AttackPlayer();
}
