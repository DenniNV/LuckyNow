using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BronzeTicket : Ticket
{
    public BronzeTicket(double reward, string ticketInfo, int cost)
    {
        Reward = reward;
        _ticketInfo = ticketInfo;
        _cost = cost;
    }
}
