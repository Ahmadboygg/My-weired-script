using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameStopwatch : MonoBehaviour
{
    [SerializeField] TMP_Text minutesString;
    [SerializeField] TMP_Text secondsString;
    private float minutes;
    private float seconds;
    public bool isRunning;
    void Start()
    {
        minutes = 0;
        seconds = 0;
        isRunning = true;
    }

    void Update()
    {
        if(isRunning)
        {
            seconds += Time.fixedDeltaTime;
            if(seconds >= 59f)
            {
                minutes++;
                seconds = 0;
            }
        }
        minutesString.text = minutes.ToString("F0");
        secondsString.text = seconds.ToString("F0");
    }

    public float GetMinutes()
    {
        return minutes;
    }

    public float GetSeconds()
    {
        return seconds;
    }
}
