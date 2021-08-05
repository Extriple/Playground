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

    Rigidbody rb;

    private int jumpTicker = 0;


    void Reset()
    {
        //Add GroundChecker
        groundChecker = GetComponentInChildren<GroundChecker>();
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //Add jump ticker mechanism. 
        if (Input.GetButtonDown("Jump") && (!groundChecker || groundChecker.isGrounded))
        {
            //Add jump ticker + add jump ticker to string
            jumpTicker++;
            text.text = "Jump Ticker: " + jumpTicker.ToString();
        }
    }

    void LateUpdate()
    {
        //Jump Input system. 
        if (Input.GetButtonDown("Jump") && (!groundChecker || groundChecker.isGrounded))
        {
            rb.AddForce(Vector3.up * 100 * jumpForce);
            Jumped?.Invoke();
        }
    }
}
