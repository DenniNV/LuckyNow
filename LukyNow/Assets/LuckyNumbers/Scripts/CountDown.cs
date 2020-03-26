using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown 
{
    private double _totalSeconds;
    public CountDown(double totalSeconds)
    {
        _totalSeconds = totalSeconds;
    }

    public double CountTime()
    {

        if(_totalSeconds > 0)
        {
            double value =   _totalSeconds -= Time.deltaTime;
            return value;
        }
        else
        {
           return _totalSeconds = 0;
        }
        
    }
}
