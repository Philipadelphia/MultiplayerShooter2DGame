using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHealth = 100;
    public int enemyMaxHealth = 100;
    public HealthBar healthbar;

    void Start()
    {
        enemyHealth = enemyMaxHealth;
        healthbar.SetMaxHealth(enemyMaxHealth);
    }

    public void TakeDamage(int damage)
    {
        enemyHealth = enemyHealth - damage;
        healthbar.SetHealth(enemyHealth);

        if (enemyHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
