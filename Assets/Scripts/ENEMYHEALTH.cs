using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 3;

    public void TakeDamage(int amount)
    {
        health -= amount;

        Debug.Log("Enemy took damage!");

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // ADD SCORE BEFORE DESTROY
        if (ScoreSystem.instance != null)
        {
            ScoreSystem.instance.AddScore(1);
        }

        Destroy(gameObject);
    }
}
