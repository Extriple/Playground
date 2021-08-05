using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    [SerializeField] private float hp = 100f;

    public Text text;

    private int times = 0;

    public void TakeDamage(float amount)
    {
        hp -= amount;
        if (hp <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        times++;
        text.text = "Enemy ticker: " + times.ToString();
        Debug.Log(times);
    }
}
