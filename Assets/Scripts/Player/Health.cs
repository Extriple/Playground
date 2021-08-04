using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float hpPoints = 100f;
    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        hpPoints = Mathf.Max(hpPoints - damage, 0);
        if (hpPoints == 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
