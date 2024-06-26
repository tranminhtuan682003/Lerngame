using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeremaining = 0;
    public bool timeisruning = true;
    public TMP_Text timetext;

    // Start is called before the first frame update
    void Start()
    {
        timeisruning = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (timeisruning)
        {
            if(timeremaining >= 0)
            {
                timeremaining += Time.deltaTime;
                displaytime(timeremaining);
            }
        }
    }
    void  displaytime(float timetodisplay)
    {
        timetodisplay += 1;
        float minutes = Mathf.FloorToInt(timetodisplay / 60);
        float seconds = Mathf.FloorToInt(timetodisplay % 60);
        timetext.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
