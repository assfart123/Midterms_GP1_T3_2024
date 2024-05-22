using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHP = 100; // Maximum health points
    private int currentHP; // Current health points

    public Image healthBarForeground; // Reference to the foreground image of the health bar

    void Start()
    {
        // Initialize currentHP to maxHP at the start
        currentHP = maxHP;

        // Update the health bar UI at the start
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        // Reduce currentHP by the damage amount
        currentHP -= damage;

        // Clamp currentHP to not fall below 0
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);

        // Update the health bar UI
        UpdateHealthBar();

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

        // Update the health bar UI
        UpdateHealthBar();
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

    void UpdateHealthBar()
    {
        if (healthBarForeground != null)
        {
            // Calculate the fill amount based on currentHP and maxHP
            float fillAmount = (float)currentHP / maxHP;

            // Update the fill amount of the health bar foreground
            healthBarForeground.fillAmount = fillAmount;
        }
    }
}
