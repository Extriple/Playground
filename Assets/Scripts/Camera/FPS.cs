using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{
    [SerializeField] private float sensitivity = 2f;
    [SerializeField] private float smooth = 1.5f;

    public Transform player;

    private Vector2 velocity;
    private Vector2 frameVelocity;

    void Reset()
    {
        // Get Movment to the ParentObject "Player"
        player = GetComponentInParent<Movement>().transform;
    }

    void Start()
    {
        // Lock the mouse cursor.
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get smooth velocity.
        Vector2 mouse = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Vector2 rawFrameVelocity = Vector2.Scale(mouse, Vector2.one * sensitivity);
        frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smooth);
        velocity += frameVelocity;
        velocity.y = Mathf.Clamp(velocity.y, -90, 90);

        //Rotate camer up-down. Rotate controller left-right. 
        transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
        player.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);

    }

}
