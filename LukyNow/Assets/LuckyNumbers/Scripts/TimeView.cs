using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeView : MonoBehaviour
{
    [SerializeField]
    private Text _timeText;
    [SerializeField]
    private double _time;
    private double _tempTime;
    private static TimeView _inst;
    private readonly Events events = Events.getInstance();

    private void Start()
    {
        _inst = this;
        events.WaitTimeEnd += StopTime;
        events.SkipTimeInLuckyNumbers += SkipTime;
    }
    private void OnApplicationQuit()
    {
        events.WaitTimeEnd -= StopTime;
    }
    public static void StopTime()
    {
        _inst.StopInst();
    }

    public static void StartTime()
    {
        _inst._tempTime = _inst._time;
        _inst.StartInst();
    }

    void StopInst()
    {
        StopAllCoroutines();
    }

    void StartInst()
    {
        StartCoroutine(RepeatingFunction());
    }
    public double CountTime()
    {
        if (_tempTime > 0)
        {
            return _tempTime -= 1;
        }
        else
        {
            events.TimeEnd();
            return _tempTime = 0;

        }
    }

    private void SkipTime()
    {
        _tempTime = 1;
    }
    IEnumerator RepeatingFunction()
    {
        while (true)
        {
            ViewTime();
            yield return new WaitForSeconds(1);
        }
    }
    public void ViewTime()
    {
        var ts = TimeSpan.FromSeconds(CountTime());
        _timeText.text = Convert.ToInt32(ts.Hours) + "h : " + Convert.ToInt32(ts.Minutes) + "m : " + Convert.ToInt32(ts.Seconds) + "s";
    }

}
