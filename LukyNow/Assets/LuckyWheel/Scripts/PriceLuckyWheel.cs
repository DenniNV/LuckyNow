using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriceLuckyWheel : Price
{
    private double _priceCoin;
    public PriceLuckyWheel(double priceCoin)
    {
        _priceCoin = priceCoin;
    }
    public override double GetPrice()
    {
        return _priceCoin;
    }
}
