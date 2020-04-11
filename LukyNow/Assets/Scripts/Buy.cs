using System;
using UnityEngine;
public class Buy 
{
    private Score _score = Score.getInstance();
    private Price _price;
    public Buy(Price price)
    {
        _price = price;
    }
    public void BuySomething()
    {
        if(_score.Coin - _price.GetPrice()>=0)
        {
            _score.MinusMoney(_price.GetPrice());
        }
        else
        {
            throw new Exception("You don't have money");
        }
    }
    public int MaxCountBuy()
    {
        return  Convert.ToInt32( _score.Coin / _price.GetPrice());
    }

}
