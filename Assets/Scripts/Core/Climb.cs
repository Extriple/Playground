using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour
{

    [SerializeField] private float speed;

    public GameObject player;
    bool canClimb = false;

    void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.tag == "Player")
        {
            canClimb = true;
            player = collision.gameObject;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canClimb = false;
            player = null;
        }
    }

    void Update()
    {
        if (canClimb)
        {
            if (Input.GetKey(KeyCode.W))
            {
                player.transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                player.transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * speed);
            }
        }
    }
}
