using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMechanism : MonoBehaviour
{
    private float value = 0f;
    
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private float limit = 75f;

    void Update()
    {
        // uniform motion of the ball
        float angle = limit * Mathf.Sin(Time.time + value * speed);
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
}
