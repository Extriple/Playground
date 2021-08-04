using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float smoothSpeed = 1f;

    public Vector3 offset;
    public Transform player;

    void FixedUpdate()
    {
        Vector3 position = player.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, position, smoothSpeed);
        transform.position = smoothPos;

        transform.LookAt(player);
    }

}
