using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RafflePrice : Price
{
    private double _priceCoin;
    public RafflePrice(double priceCoin)
    {
        _priceCoin = priceCoin;
    }
    public override double GetPrice()
    {
        return _priceCoin;
    }
}
