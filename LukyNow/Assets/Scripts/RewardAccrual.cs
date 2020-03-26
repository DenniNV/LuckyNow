using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardAccrual
{
    protected Score score = Score.getInstance();

    public void Accrual(double coins , int dollars)
    {
        score.Coin = coins;
        score.Dollar = dollars;
    }

}
