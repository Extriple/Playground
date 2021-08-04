using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rigidbody;
    private float pushForce;
    private Vector3 pushDirection;
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    public void HitPlayer(Vector3 velocityForce)
    {
        rigidbody.velocity = velocityForce;
        pushDirection = Vector3.Normalize(velocityForce);
        

    }
}
