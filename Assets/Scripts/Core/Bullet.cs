using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject pfBullet;


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(pfBullet, transform.position, transform.rotation) as GameObject;
            Rigidbody rbBullet = bullet.GetComponent<Rigidbody>();
            rbBullet.AddForce(transform.forward * 1000f);
            Destroy(rbBullet.gameObject, 2f);


        }
    }



}
