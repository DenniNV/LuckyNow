using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TicketCreator : MonoBehaviour
{
    public Ticket orderTicket(int id)
    {
        Ticket ticket = null;
        ticket = CreateTicket(id);
        return ticket;

    }

    public abstract Ticket CreateTicket(int id);

}
