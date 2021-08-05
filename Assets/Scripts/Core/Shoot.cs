using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    [SerializeField] float damage = 20f;
    [SerializeField] float range = 200f;
    [SerializeField] float bulletSpeed = 50f;

    public Camera playerCamera;
    public ParticleSystem particleSystemWeapon;
    public Text killsCounter;
    public GameObject ammo;

    int score = 0;


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            particleSystemWeapon.Play();
            Shooting();
            
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
            Rigidbody rbBullet = bullet.GetComponent<Rigidbody>();
             rbBullet.AddForce(transform.forward * 3000f);
            Destroy(rbBullet.gameObject, 2f);
        }
    }

}
