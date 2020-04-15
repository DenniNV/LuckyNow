using UnityEngine;

public class RewardEveryday : Reward
{
    private int _day;
    public RewardEveryday(double coin, double dollar, int day)
    {
        _day = day;
        _rewardCoin = coin;
        _rewardDollars = dollar;

    }
}
