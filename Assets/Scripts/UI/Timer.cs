using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float timer;

    public Text timerTxt;
    public bool isPlaying;


    void Update()
    {
        if (isPlaying == true)
        {
            timer += Time.deltaTime;
            int min = Mathf.FloorToInt(timer / 60f);
            int sec = Mathf.FloorToInt(timer % 60f);
            timerTxt.text = min.ToString("00") + ":" + sec.ToString("00");
        }
    }
}
