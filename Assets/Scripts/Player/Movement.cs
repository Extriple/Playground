using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 6f;

    Rigidbody rigidbody;



    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

        void FixedUpdate()
        {
            float movingSpeed = speed;

            // Get targetVelocity from input.
            Vector2 targetVelocity = new Vector2(Input.GetAxis("Horizontal") * movingSpeed, Input.GetAxis("Vertical") * movingSpeed);

            // Apply movement.
            rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);
        }
}
