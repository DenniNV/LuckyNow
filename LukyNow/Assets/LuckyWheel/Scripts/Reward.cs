using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Reward
{
    protected double _rewardCoin;
    protected double _rewardDollars;
    public double RewardCoin => _rewardCoin;
    public double RewardDollar => _rewardDollars;
}
