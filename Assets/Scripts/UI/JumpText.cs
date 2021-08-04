using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JumpText : MonoBehaviour
{
    public Text text;
    public bool isPlaying;

    private int times = 0;


    void Update()
    {
        if(isPlaying)
        {
            if (Input.GetButton("Jump"))
            {
                times++;
                text.text = times.ToString();
            }
        }
    }
}
