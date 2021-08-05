using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    [SerializeField] float damage = 20f;
    [SerializeField] float range = 1000f;
    [SerializeField] float bulletSpeed = 50f;

    public Camera playerCamera;
    public ParticleSystem particleSystemWeapon;
    public Text killsCounter;
    public GameObject ammo;
    public TextMeshProUGUI meshPro;

    int score = 0;

    void Start()
    {
        //Winner text active, when you win the game
        killsCounter.text = "Kills: " + 0;
        meshPro.GetComponent<TextMeshProUGUI>();
        meshPro.gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            particleSystemWeapon.Play();
            Shooting();
            Winner();
            
        }
    }

    void Shooting()
    {
        //weapon targeting and mouse targeting system
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {
            //Take damage from enemy
            Target target  = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
                if (target.isDead)
                {
                    //Count score when enemy die
                    score++;
                    killsCounter.text = "Kills: " + score.ToString(); 
                }
            }
            //Bullet trajectory with raycast.
            GameObject bullet = Instantiate(ammo, transform.position, transform.rotation) as GameObject;
             bullet.GetComponent<Rigidbody>().velocity = (hit.point - transform.position).normalized * bulletSpeed;
            Destroy(bullet.gameObject, 2f);
        }
    }

    public void Winner()
    {
        //Quest "Win the game" 
        if (score == 11)
        {
            meshPro.gameObject.SetActive(true);
        }
    }
}
