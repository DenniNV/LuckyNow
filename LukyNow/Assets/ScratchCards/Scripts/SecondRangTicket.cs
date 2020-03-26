using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondRangTicket : TicketCreator
{
    public override Ticket CreateTicket(int id)
    {
        Ticket ticket = null;
        switch (id)
        {
            case 1:
                ticket = new BronzeTicket(1000, "This is first ticket", 800);
                return ticket;
            case 2:
                ticket = new SilverTicket(1500, "This is first ticket", 1200);
                return ticket;
            case 3:
                ticket = new GoldTicket(2000, "This is first ticket", 1600);
                return ticket;
            default:
                throw new IndexOutOfRangeException();

        }
    }
}
