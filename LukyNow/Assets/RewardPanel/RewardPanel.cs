using System;
using System.Collections.Generic;
using UnityEngine;

public class RewardPanel 
{
    private RewardViewPanel _rewardView;

    private static RewardPanel instance;

    private RewardPanel()
    { }

    public static RewardPanel getInstance()
    {
        if (instance == null)
            instance = new RewardPanel();
        return instance;
    }
    public void Constructor(RewardViewPanel  rewardView)
    {
        _rewardView = rewardView;
    }
   
    public void AddReward(double coin , double dollar)
    {
        if(_rewardView == null) { throw new NullReferenceException(); }
        _rewardView.RewardCoin = coin;
        _rewardView.RewrdDollar = dollar;
        _rewardView.UpdateText();
        _rewardView.OpenPanel();
    }

}
