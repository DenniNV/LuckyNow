using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverTicket : Ticket
{
    public SilverTicket(int reward, string ticketInfo, int cost)
    {
        Reward = reward;
        _ticketInfo = ticketInfo;
        _cost = cost;
    }
}
