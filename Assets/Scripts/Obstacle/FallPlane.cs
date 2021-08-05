using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlane : MonoBehaviour
{
    [SerializeField] private float time = 1f;
    [SerializeField] private float setActiveTrue = 15f;

    void OnCollisionEnter(Collision collision)
    {
        foreach(ContactPoint contactPoint in collision.contacts)
        {
            if (collision.gameObject.tag == "Player")
            {
                StartCoroutine(FallDown(time));
            }
        }
    }

    IEnumerator FallDown(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
