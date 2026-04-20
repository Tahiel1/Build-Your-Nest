using UnityEngine;

public abstract class EnemyClass : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;   // Drag your player here in Inspector
    [SerializeField] private float speed = 3f;
    [SerializeField] private float atackDistance = 8;



    void Update()
    {
        float playerDistance = Vector2.Distance(transform.position, playerTransform.position);
        if (playerTransform != null && playerDistance <= atackDistance)
        {

            // Move enemy toward player
            transform.position = Vector2.MoveTowards(
                transform.position,
                playerTransform.position,
                speed * Time.deltaTime
            );

        }
        else
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            transform.Rotate(0, 0, 100 * Time.deltaTime);
        }
    }
}
