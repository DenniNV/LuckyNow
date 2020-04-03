using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RufleCount 
{

    private int _countTicketOneDollar;
    private int _countTicketFiftyDollar;
    private int _countTicketHundredDollar;

    public int CountTicketOneDollar { set => _countTicketOneDollar = value; get => _countTicketOneDollar; }
    public int CountTicketFiftyDollar { set => _countTicketFiftyDollar = value; get => _countTicketFiftyDollar; }
    public int CountTicketHundredDollar { set => _countTicketHundredDollar = value; get => _countTicketHundredDollar; }
    private static RufleCount instance;

    public void UPCoin(int index)
    {
        switch (index)
        {
            case 1:
                _countTicketOneDollar++;
                Events.getInstance().Update();
                break;
            case 2:
                _countTicketFiftyDollar++;
                Events.getInstance().Update();
                break;
            case 3:
                _countTicketHundredDollar++;
                Events.getInstance().Update();
                break;
            default:
                throw new ArgumentException();
        }
    }
    
    private RufleCount()
    { }

    public static RufleCount getInstance()
    {
        if (instance == null)
            instance = new RufleCount();
        return instance;
    }
}
