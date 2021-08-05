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
        //Show health on the screen.
        text.text = "Health: " + hpPoints.ToString();
    }

    public bool IsDead()
    {
        //Check hp 
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        //Take damage function
        hpPoints = Mathf.Max(hpPoints - damage, 0);
        if (hpPoints == 0)
        {
            isDead = true;
            Die();
        }
    }

    public void Die()
    {
        //Reload scene when player die
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
