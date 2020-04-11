using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RaffleCount 
{

    private int _countTicketOneDollar;
    private int _countTicketFiftyDollar;
    private int _countTicketHundredDollar;

    public int CountTicketOneDollar { set => _countTicketOneDollar = value; get => _countTicketOneDollar; }
    public int CountTicketFiftyDollar { set => _countTicketFiftyDollar = value; get => _countTicketFiftyDollar; }
    public int CountTicketHundredDollar { set => _countTicketHundredDollar = value; get => _countTicketHundredDollar; }

    public void AddCountTickets(int index, int count)
    {
        switch (index)
        {
            case 1:
                _countTicketOneDollar += count;
                Events.getInstance().Update();
                break;
            case 2:
                _countTicketFiftyDollar += count;
                Events.getInstance().Update();
                break;
            case 3:
                _countTicketHundredDollar += count;
                Events.getInstance().Update();
                break;
            default:
                throw new ArgumentException();
        }
    }
    public int GetCountTicket(int index)
    {
        switch (index)
        {
            case 1:
                return _countTicketOneDollar;
            case 2:
                return _countTicketFiftyDollar;
            case 3:
                return _countTicketHundredDollar;
            default:
                throw new IndexOutOfRangeException();
        }
    }
    #region Singelton
    private RaffleCount()
    { }
    private static RaffleCount instance;
    public static RaffleCount getInstance()
    {
        if (instance == null)
            instance = new RaffleCount();
        return instance;
    }
    #endregion
}
