using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float hpPoints = 100f;


    public Text text;
    bool isDead = false;

    void Update()
    {
        text.text = "Health: " + hpPoints.ToString();
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        hpPoints = Mathf.Max(hpPoints - damage, 0);
        if (hpPoints == 0)
        {
            isDead = true;
            Die();
        }
    }

    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
