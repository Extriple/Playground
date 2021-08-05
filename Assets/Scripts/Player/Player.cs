using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private float pushForce;
    private Vector3 pushDirection;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void HitPlayer(Vector3 velocityForce)
    {
        rb.velocity = velocityForce;
        pushDirection = Vector3.Normalize(velocityForce);
        

    }
}
