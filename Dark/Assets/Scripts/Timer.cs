using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{   
    public Text timerText;
    private float startTime;

    public string minutes;
    public string seconds;
    public string totalTime;

    void Start()
    {
        startTime = Time.time;
    }

    public void Update()
    {
        float t = Time.time - startTime;

        minutes = ((int) t / 60).ToString();
        seconds  = (t % 60).ToString("f1");
        timerText.text ="Time Survived: " + minutes + ":" + seconds;
        totalTime = minutes + ":" + seconds;
    }
}
