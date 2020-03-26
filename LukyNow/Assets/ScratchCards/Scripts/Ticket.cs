using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ticket : Reward
{
    public double Reward { set => _rewardCoin += value; get => _rewardCoin; }

    protected string _ticketInfo;
    public string TicketInfo => _ticketInfo;

    protected int _cost;
    public int Cost => _cost;




}
