using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    private static Score instance;

    private int _dollar = 0;
    public int Dollar { set { _dollar += value; UpdateDollar(); } }

    private int _coin = 0;
    public int Coin { set { _coin += value; UpdateCoin(); }  }
    private Score()
    { }
    public static Score getInstance()
    {
        if (instance == null)
            instance = new Score();
        return instance;
    }

    private Events _event = Events.getInstance();

    private void UpdateCoin()
    {
        _event.CoinUpp(_coin); 
    }

    private void UpdateDollar()
    {
        _event.DollarUpp(_dollar);
    }

}
