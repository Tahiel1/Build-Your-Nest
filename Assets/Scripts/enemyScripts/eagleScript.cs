using UnityEngine;

public class eagleScript : EnemyClass
{
    public override void AttackPlayer()
    {
        Debug.Log("Eagle is attacking the player!");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AttackPlayer();
        }
    }
}
