using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwardAccrualLuckyNumbers: IAwardAccrual
{
    private readonly Reward _reward = new RewardInLuckyNumbers(100 , 100);
    private readonly RewardAccrual _rewardAccrual = new RewardAccrual();
    private Events _events = Events.getInstance();

    public void AwardAccrual()
    {
        _rewardAccrual.Accrual(_reward.RewardCoin, _reward.RewardDollar);
    }

   
}
