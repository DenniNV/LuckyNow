using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    private static Score instance;
    private double _dollar = 0;
    public double Dollar { set => _dollar = value; get => _dollar; }
    private double _coin = 0;
    public double Coin { set => _coin = value; get => _coin; }
    private Score()
    { }
    public static Score getInstance()
    {
        if (instance == null)
            instance = new Score();
        return instance;
    }

    private Events _event = Events.getInstance();


    public void PlusMoney(double coin , double dollar)
    {
        _coin += coin;
        _dollar += dollar;
        UpdateMoney();
    }
    public void MinusMoney(double coin)
    {
        _coin -= coin;
        UpdateMoney();
    }
    private void UpdateCoin()
    {
        _event.CoinUpp(_coin); 
    }

    private void UpdateDollar()
    {
        _event.DollarUpp(_dollar);
    }
    private void UpdateMoney()
    {
        UpdateCoin();
        UpdateDollar();
    }
    

}
