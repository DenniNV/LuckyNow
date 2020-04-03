using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeView : MonoBehaviour
{
    [SerializeField]
    private Text _timeTextLuckNumbers;

    [SerializeField]
    private Text[] _timeTextRufle;

    [SerializeField]
    private double _timeLuckyNumbers;
    [SerializeField]
    private double _timeRufle;


    private double _tempTimeRufle;
    private double _tempTimeLuckyNumbers;
    private static TimeView _inst;
    private readonly Events events = Events.getInstance();

    private void Start()
    {
        _inst = this;
        events.WaitTimeEnd += StopTime;
        events.SkipTimeInLuckyNumbers += SkipTime;
        StartTime();
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
        _inst._tempTimeLuckyNumbers = _inst._timeRufle;
        _inst._tempTimeRufle = _inst._timeRufle;
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
    public double CountTimeLuckyNumbers()
    {
        if (_tempTimeLuckyNumbers > 0)
        {
            return _tempTimeLuckyNumbers -= 1;
        }
        else
        {
            events.TimeEnd();
            return _tempTimeLuckyNumbers = 0;

        }
    }
    public double CountTimeRufle()
    {
        if (_tempTimeRufle > 0)
        {
            return _tempTimeRufle -= 1;
        }
        else
        {
            //events.TimeEnd();
            return _tempTimeRufle = 0;

        }
    }

    private void SkipTime()
    {
        _tempTimeLuckyNumbers = 1;
    }
    IEnumerator RepeatingFunction()
    {
        while (true)
        {
            ViewTime();
            ViewTimeRufle();
            yield return new WaitForSeconds(1);
        }
    }
    public void ViewTime()
    {
        var ts = TimeSpan.FromSeconds(CountTimeLuckyNumbers());
        _timeTextLuckNumbers.text = Convert.ToInt32(ts.Hours) + "h : " + Convert.ToInt32(ts.Minutes) + "m : " + Convert.ToInt32(ts.Seconds) + "s";
    }
    public void ViewTimeRufle()
    {
        var ts = TimeSpan.FromSeconds(CountTimeRufle());
        for (int i = 0; i < _timeTextRufle.Length; i++)
        {
            _timeTextRufle[i].text = "Drawing in :" + Convert.ToInt32(ts.Days) + "D " + Convert.ToInt32(ts.Hours) +"H "  + Convert.ToInt32(ts.Minutes) + "M " +  Convert.ToInt32(ts.Seconds)+"S "  ;
        }
    }


}
