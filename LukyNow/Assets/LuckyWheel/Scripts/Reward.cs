using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Reward
{
    protected double _rewardCoin;
    protected int _rewardDollars;
    public double RewardCoin => _rewardCoin;
    public int RewardDollar => _rewardDollars;
}
