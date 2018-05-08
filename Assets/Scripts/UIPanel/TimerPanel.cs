using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerPanel : BasePanel
{
    public float Timer = 20;
    private Text TimeText;
    private bool TimeStart = false;
    public override void OnEnter()
    {
        base.OnEnter();
        TimeText = transform.Find("Text").GetComponent<Text>();
        TimeStart = true;

    }
    
    void Update()
    {
        if (TimeStart)
        {
            Timer -= Time.deltaTime;
            TimeText.text =Timer.ToString("0");
            if (Timer <= 0)
            {
                TimeStart = false;
            }
        }

    }
}
