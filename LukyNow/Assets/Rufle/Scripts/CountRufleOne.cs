using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountRufleOne :IRufleCount
{
    private RufleCount rufleCount = RufleCount.getInstance();
    public void UpCount()
    {
        rufleCount.CountTicketFiftyDollar += 1;
        Events.getInstance().Update();
    }


}
