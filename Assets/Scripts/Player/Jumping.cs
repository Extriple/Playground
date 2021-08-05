using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    [SerializeField] private float jumpForce = 2;
    
    Rigidbody rigidbody;

    public event System.Action Jumped;
    [SerializeField, Tooltip("Prevents jumping when the transform is in mid-air.")]
    GroundChecker groundChecker;


    void Reset()
    {
        groundChecker = GetComponentInChildren<GroundChecker>();
    }

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        if (Input.GetButtonDown("Jump") && (!groundChecker || groundChecker.isGrounded))
        {
            rigidbody.AddForce(Vector3.up * 100 * jumpForce);
            Jumped?.Invoke();
        }
    }
}
