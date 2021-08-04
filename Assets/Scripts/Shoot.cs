using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] float damage = 20f;
    [SerializeField] float range = 100f;

    public Camera camera;
    public ParticleSystem particleSystem;


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            particleSystem.Play();
            Shooting();
        }
    }

    void Shooting()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target  = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }

}
