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
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {
            Target target  = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
                if (target.isDead)
                {
                    score++;
                    killsCounter.text = "Kills: " + score.ToString(); 
                }
            }
            GameObject bullet = Instantiate(ammo, transform.position, transform.rotation) as GameObject;
             bullet.GetComponent<Rigidbody>().velocity = (hit.point - transform.position).normalized * bulletSpeed;
            Destroy(bullet.gameObject, 2f);
        }
    }

    public void Winner()
    {
        if (score == 11)
        {
            meshPro.gameObject.SetActive(true);
        }
    }
}
