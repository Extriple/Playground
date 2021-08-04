using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public CharacterController controller;
    public Transform cameraTransform;

    [SerializeField] private float speed = 6f;
    [SerializeField] private float turnSmoothTime = 0.1f;

    private float smoothVelocity;

    void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontalMovement, 0f, verticalMovement).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float target = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float smooth = Mathf.SmoothDampAngle(transform.eulerAngles.y, target, ref smoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, smooth, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, target, 0f) * Vector3.forward;

            controller.Move(moveDirection * speed * Time.deltaTime);
        }

    }
}
