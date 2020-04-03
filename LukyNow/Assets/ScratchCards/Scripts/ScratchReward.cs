using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchReward : Reward
{
    public ScratchReward(int dollars , double coin)
    {
        _rewardDollars = dollars;
        _rewardCoin = coin;

    }
}
