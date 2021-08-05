using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatationX : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float damage = 60f;

    void Update()
    {
        transform.Rotate(0f, 0f, speed * Time.deltaTime / 0.01f, Space.Self);
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<Health>().TakeDamage(damage);
                return;
            }
        }
    }
}
