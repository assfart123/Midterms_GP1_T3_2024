using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHP = 100; // Maximum health points
    private int currentHP; // Current health points

    void Start()
    {
        // Initialize currentHP to maxHP at the start
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        // Reduce currentHP by the damage amount
        currentHP -= damage;

        // Check if currentHP has fallen below or equal to 0
        if (currentHP <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        // Increase currentHP by the healing amount, without exceeding maxHP
        currentHP = Mathf.Min(currentHP + amount, maxHP);
    }

    void Die()
    {
        // Handle the unit's death (e.g., destroy the GameObject)
        Destroy(gameObject);
    }

    public int GetCurrentHP()
    {
        // Returns the current HP
        return currentHP;
    }
}
