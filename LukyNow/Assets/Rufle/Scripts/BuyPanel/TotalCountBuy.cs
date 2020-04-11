using System;
using UnityEngine;

public class TotalCountBuy 
{
    private int _countBuy = 1;
    private int _maxCountBuy;
    public int MaxCountBuy { set => _maxCountBuy = value; get => _maxCountBuy; }
    public int CountBuy { set {
            
            _countBuy = value;
            Validate();
        }
        get => _countBuy; 
    }

    public void Validate()
    {
        if(_countBuy >= _maxCountBuy)
        {
            _countBuy = _maxCountBuy;
        }
        else if (_countBuy < 1)
        {
            _countBuy = 1;
        }
    }
    #region Singleton
    private static TotalCountBuy instance;
    private TotalCountBuy()
    { }
    public static TotalCountBuy getInstance()
    {
        if (instance == null)
            instance = new TotalCountBuy();
        return instance;
    }
    #endregion
}
