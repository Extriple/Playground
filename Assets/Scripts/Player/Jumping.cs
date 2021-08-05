using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jumping : MonoBehaviour
{
    [SerializeField] private float jumpForce = 2;
    [SerializeField, Tooltip("Prevents jumping when the transform is in mid-air.")]
    GroundChecker groundChecker;
    
    public event System.Action Jumped;
    public Text text;

    Rigidbody rigidbody;

    private int jumpTicker = 0;


    void Reset()
    {
        groundChecker = GetComponentInChildren<GroundChecker>();
    }

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump") && (!groundChecker || groundChecker.isGrounded))
        {
            jumpTicker++;
            text.text = "Jump Ticker: " + jumpTicker.ToString();
        }
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
