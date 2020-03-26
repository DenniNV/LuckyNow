using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FirstRangTicket : TicketCreator
{
    public override Ticket CreateTicket(int id)
    {
        Ticket ticket = null;
        switch (id)
        {
            case 1:
                ticket = new BronzeTicket(150, "This is first ticket", 100);
                return ticket;
            case 2:
                ticket = new SilverTicket(300, "This is first ticket", 200);
                return ticket;
            case 3:
                ticket = new GoldTicket(600, "This is first ticket", 400);
                return ticket;
            default:
                throw new IndexOutOfRangeException();

        }
    }
}
