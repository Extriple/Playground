using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{

    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpSpeed = 8f;
    [SerializeField] private float gravity = 10f;
    [SerializeField] private float look = 3f;
    [SerializeField] private float lookSize = 50f;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    Vector2 rotation = Vector2.zero;

    ///public Transform playerCamera;
    public bool canMove = true;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Start()
    {
        rotation.y = transform.eulerAngles.y;
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
            float currentlySpeedX = canMove ? speed * Input.GetAxis("Vertical") : 0;
            float currentlySpeedY = canMove ? speed * Input.GetAxis("Horizontal") : 0;
            moveDirection = (forward * currentlySpeedX) + (right * currentlySpeedY);

            if (Input.GetButton("Jump") && canMove)
            {
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotation.y += Input.GetAxis("Mouse X") * look;
            rotation.x += Input.GetAxis("Mouse Y") * look;
            rotation.x = Mathf.Clamp(rotation.x, -lookSize, look);
            //playerCamera.localRotation = Quaternion.Euler(rotation.x, 0, 0);
            transform.eulerAngles = new Vector2(0, rotation.y);
        }
    }
}
