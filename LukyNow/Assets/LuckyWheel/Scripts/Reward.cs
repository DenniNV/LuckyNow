using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Reward
{
    protected int _rewardCoin;
    protected int _rewardDollars;
    public int RewardCoin => _rewardCoin;
    public int RewardDollar => _rewardDollars;
}
