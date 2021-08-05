using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPower : MonoBehaviour
{
    [SerializeField] private float force = 15f;
    [SerializeField] private float damage = 20f;
    private Vector3 hitDirection;

    void OnCollisionEnter(Collision collision)
    {
        foreach(ContactPoint contact in collision.contacts)
        {
            //Take damage and push back when Player is on the collision
            if (collision.gameObject.tag == "Player")
            {
                hitDirection = contact.normal;
                collision.gameObject.GetComponent<Player>().HitPlayer(-hitDirection * force);
                collision.gameObject.GetComponent<Health>().TakeDamage(damage);
                return;
            }
        }
    }
}
