using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchReward : Reward
{
    public ScratchReward(double dollars , double coin)
    {
        _rewardDollars = dollars;
        _rewardCoin = coin;

    }
}
