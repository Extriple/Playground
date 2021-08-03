using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPower : MonoBehaviour
{
    [SerializeField] private float force = 15f;
    private Vector3 hitDirection;


    void OnCollisionEnter(Collision collision)
    {
        foreach(ContactPoint contact in collision.contacts)
        {
            if (collision.gameObject.tag == "Player")
            {
                hitDirection = contact.normal;
                collision.gameObject.GetComponent<Player>().HitPlayer(-hitDirection * force);
                return;
            }
        }
    }
}
