using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardLuckyWheel:Reward
{
    private float _angle;
    public float Angle => _angle;   
    public RewardLuckyWheel(double rewardCoin, double rewardDollar, float angle)
    {
        _rewardCoin = rewardCoin;
        _angle = angle;
        _rewardDollars = rewardDollar;
    }


}
