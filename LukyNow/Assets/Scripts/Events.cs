using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events 
{
    private static Events instance;

    private Events()
    { }

    public static Events getInstance()
    {
        if (instance == null)
            instance = new Events();
        return instance;
    }

    public void CoinUpp(int coin)
    {
        UpCoin?.Invoke(coin);
    }

    public void DollarUpp(int dollar)
    {
        UpDollar?.Invoke(dollar);
    }

    public delegate void Coin(int coin);
    public event Coin UpCoin;
    public delegate void Dollar(int dollar);
    public event Dollar UpDollar;

}
