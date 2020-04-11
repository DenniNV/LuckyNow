using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardAccrual
{
    protected Score score = Score.getInstance();

    public void Accrual(double coins , double dollars)
    {
        score.PlusMoney(coins, dollars);
        
    }

}
