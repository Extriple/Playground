using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlane : MonoBehaviour
{
    [SerializeField] private float time = 1f;

    void OnCollisionEnter(Collision collision)
    {
        //When player touch a plane, he/she has a 1 sec to jump on the other, because plane deactives
        foreach(ContactPoint contactPoint in collision.contacts)
        {
            if (collision.gameObject.tag == "Player")
            {
                StartCoroutine(FallDown(time));
            }
        }
    }

    //Deactive plane after 1 sec
    IEnumerator FallDown(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
