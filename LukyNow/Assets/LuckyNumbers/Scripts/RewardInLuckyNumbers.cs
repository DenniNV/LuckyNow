using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardInLuckyNumbers : Reward
{
    public RewardInLuckyNumbers(double coin, int dollar)
    {
        _rewardCoin = coin;
        _rewardDollars = dollar;
    }

}
