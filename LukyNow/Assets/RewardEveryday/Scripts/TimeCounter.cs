using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCounter 
{
    DateTime RewardedDT;
    private int _dataReward =1;
    private static TimeCounter instance;
    private TimeCounter()
    { }
    public static TimeCounter getInstance()
    {
        if (instance == null)
            instance = new TimeCounter();
        return instance;
    }
    private RewardPanel rewardPanel = RewardPanel.getInstance();
    private Reward[] _rewards =
    {
        new RewardEveryday(2000,0,1),
        new RewardEveryday(3000,0,2),
        new RewardEveryday(4000,0,3),
        new RewardEveryday(7000,0,4),
        new RewardEveryday(8000,0,5),
        new RewardEveryday(12000,0,6),
        new RewardEveryday(12000,0,7)
    };
    private List<RewardEverydayView> _rewardEverydayViews = new List<RewardEverydayView>();
    public void AddRewardEveryday(RewardEverydayView rewardEverydayView)
    {
        _rewardEverydayViews.Add(rewardEverydayView);
        _rewardEverydayViews.Sort();
    }
    public void SaveTime()
    {
        RewardedDT = DateTime.Now.AddDays(1);
        PlayerPrefs.SetInt("RewardedYear", RewardedDT.Year);
        PlayerPrefs.SetInt("RewardedMonth", RewardedDT.Month);
        PlayerPrefs.SetInt("RewardedDay", RewardedDT.Day);
        PlayerPrefs.SetInt("RewardedHour", RewardedDT.Hour);
        PlayerPrefs.SetInt("RewardedMinute", RewardedDT.Minute);
        PlayerPrefs.SetInt("RewardedSecond", RewardedDT.Second);
    }
    public void CheckReward()
    {
        if (true)//CheckTime())
        {
            _rewardEverydayViews.Sort();
            foreach(RewardEveryday r in _rewards)
            {
                if(r.Day == _dataReward)
                {
                    rewardPanel.AddReward(r.RewardCoin, r.RewardDollar);
                    _rewardEverydayViews[_dataReward-1].Dedicated();
                    try
                    {
                        _rewardEverydayViews[_dataReward].NextRecived();
                        Debug.Log(_dataReward);
                    }
                    catch
                    {
                        _dataReward = 0;
                        foreach(RewardEverydayView v in _rewardEverydayViews)
                        {
                            v.UnDedicated();
                        }
                    }
                }
            }
            if (_dataReward >= 7)
            {
                _dataReward = 1;

            }
            else
            {
                _dataReward++;
            }
            SaveTime();
            Events.getInstance().OpenOrCloseEveryDayPanel(false);
        }
    }

    private bool CheckTime()
    {
        DateTime RewardedDT = new DateTime(PlayerPrefs.GetInt("RewardedYear", DateTime.Now.Year), PlayerPrefs.GetInt("RewardedMonth", DateTime.Now.Month), PlayerPrefs.GetInt("RewardedDay", DateTime.Now.Day),
                                           PlayerPrefs.GetInt("RewardedHour", DateTime.Now.Hour), PlayerPrefs.GetInt("RewardedMinute", DateTime.Now.Minute), PlayerPrefs.GetInt("RewardedSecond", DateTime.Now.Second));
        if (RewardedDT <= DateTime.Now && (DateTime.Now - RewardedDT).Days == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }  
}
