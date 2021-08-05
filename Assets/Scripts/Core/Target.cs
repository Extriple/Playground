using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    [SerializeField] private float hp = 100f;

    public bool isDead = false;
  

    public void TakeDamage(float amount)
    {
        //Enemy take damage function
        hp -= amount;
        if (hp <= 0f)
        {
            Die();
        }
    }

    //Kill enemy
    void Die()
    {
        isDead = true;
        Destroy(gameObject);
    }
}
